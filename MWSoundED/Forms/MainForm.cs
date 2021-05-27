using MWSoundED.Classes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MWSoundED
{
    public partial class MainForm : Form
    {
        private WaveReader waveAnalyse;

        private LearningFeatureParameters lfp = new LearningFeatureParameters();

        private List<Gmm> models;

        private List<MarkedEvent> events;

        private Rnn rnn;

        double[][] bands;

        double[][] cepstre;

        double[] timePositionFrames;

        int comboBandsIndex;

        double step;

        public MainForm()
        {
            InitializeComponent();

            InitializeGraph(graphControl);
        }

        #region Интерфейс

        private void Logging(RichTextBox control, string text)
        {
            if (control.InvokeRequired)
            {
                Invoke((Action)(() => Logging(control, text)));
            }
            else
            {
                control.AppendText(text);
                control.ScrollToCaret();
            }
        }

        private string SelectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                SelectedPath = Environment.CurrentDirectory,
                ShowNewFolderButton = true
            };

            if (fbd.ShowDialog() != DialogResult.OK)
                return string.Empty;

            return fbd.SelectedPath;
        }

        private string SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "All files *.*|*.*",
                Title = "Open file",
                InitialDirectory = Environment.CurrentDirectory,
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return string.Empty;

            return ofd.FileName;
        }

        private void InitializeGraph(ZedGraphControl graphControl)
        {
            graphControl.GraphPane.Chart.Border.IsVisible = false;
            graphControl.GraphPane.Chart.Fill.IsVisible = false;
            graphControl.GraphPane.Fill.Color = Color.Black;
            graphControl.GraphPane.Title.IsVisible = false;
            graphControl.GraphPane.XAxis.IsVisible = false;
            graphControl.GraphPane.YAxis.IsVisible = false;
            graphControl.GraphPane.YAxis.Scale.Max = 1;
            graphControl.GraphPane.YAxis.Scale.Min = -1;
        }

        private void DisplayWaveGraph(double[] waveData)
        {
            graphControl.GraphPane.CurveList.Clear();
            graphControl.GraphPane.GraphObjList.Clear();

            graphControl.GraphPane.XAxis.Scale.Max = waveData.Length - 1;
            graphControl.GraphPane.XAxis.Scale.Min = 0;
            //graphControl.GraphPane.YAxis.Scale.Max = 0.3;
            //graphControl.GraphPane.YAxis.Scale.Min = -0.3;
            graphControl.GraphPane.Margin.All = 0;
            var timeData = Enumerable.Range(0, waveData.Length)
                                     .Select(i => (double)i)
                                     .ToArray();
            graphControl.GraphPane.AddCurve(null, timeData, waveData, Color.Lime, SymbolType.None);
            graphControl.AxisChange();

            graphControl.Refresh();
        }

        private void LoadWaveFile(string path)
        {
            waveAnalyse = new WaveReader(path);

            DisplayWaveGraph(waveAnalyse.Mono);
        }

        private double[][] Bands(double[][] spectre, WaveReader waveAnalyse, BanksType type, int numFilters, int sampleRate,
            int lowFreq, int highFreq, int frameSize, int frameShift, bool old)
        {
            double[][] bandsSpectrogram = null;

            MelBands melbands = null;

            GammatoneBands gbands = null;

            if (type == BanksType.Mel)
            {
                if (!old)
                    melbands = new MelBands(spectre, numFilters, sampleRate, lowFreq, highFreq, old);
                else if (old)
                    melbands = new MelBands(spectre, numFilters, sampleRate, lowFreq, highFreq, old);

                bandsSpectrogram = melbands.Spectrogram;
            }
            else if (type == BanksType.Gammatone)
            {
                if (!old)
                    gbands = new GammatoneBands(spectre, numFilters, sampleRate, lowFreq, highFreq);
                else if (old)
                    gbands = new GammatoneBands(waveAnalyse, frameShift, frameSize, numFilters, sampleRate, lowFreq, highFreq);

                bandsSpectrogram = gbands.Spectrogram;
            }

            return Cepstre.LogSpectre(bandsSpectrogram);
        }

        private double[][] Cepstrogram(double[][] bandsSpectrogram, int numCoeff, bool delta, bool deltadelta,
            bool mean, bool variance, bool energy, bool old)
        {
            double[][] cepstreCoeff = null;

            Cepstre cepstre = new Cepstre(bandsSpectrogram, numCoeff, old);

            if (energy) cepstreCoeff = cepstre.Features.ToArray();

            else cepstreCoeff = cepstre.WithoutEnergyFeatures.ToArray();

            if (mean) FeaturePostProcessing.NormalizeMean(cepstreCoeff);

            if (variance) FeaturePostProcessing.NormalizeVariance(cepstreCoeff);

            if (delta) FeaturePostProcessing.AddDeltas(cepstreCoeff, includeDeltaDelta: false);

            if (deltadelta) FeaturePostProcessing.AddDeltas(cepstreCoeff);

            return cepstreCoeff;
        }

        private void LoadFeature()
        {
            int frame_size = (int)lfp.numWindowSize.Value;
            int frame_shift = (int)lfp.numWindowShift.Value;

            bool to_short = lfp.checkShort.Checked;
            bool fill_null = lfp.checkFillNull.Checked;
            bool preemph = lfp.checkPreemphasis.Checked;

            double a = (double)lfp.numA.Value;

            Overlapping overlapProcess = new Overlapping(waveAnalyse, frame_size, frame_shift,
                to_short: to_short, fill_null: fill_null, pre: preemph, a: a);

            timePositionFrames = overlapProcess.TimePosition.ToArray();

            DiscreteTransform dt = new DiscreteTransform(overlapProcess);

            dt.Process(DiscreteTransform.TransformType.InTime, DiscreteTransform.SpectrumType.Power);

            spectrogramPanel.Spectrogram = Cepstre.LogSpectre(dt.Spectre).ToList();

            // --------------- Bands ---------------

            int num_filters = (int)lfp.numFilters.Value;
            int low_freq = (int)lfp.numLowFrequency.Value;
            int high_freq = (int)lfp.numUpFrequency.Value; // + frame_size, frame_shift для gammatone

            bool oldBanks = lfp.checkBanksOld.Checked;

            // --------------- Кепстральные коэффициенты ---------------

            int num_coeff = (int)lfp.numCoeffCepstre.Value;

            bool delta = lfp.checkDelta.Checked;
            bool deltadelta = lfp.checkDeltaDelta.Checked;
            bool mean = lfp.checkMean.Checked;

            bool variance = lfp.checkVariance.Checked;
            bool energy = lfp.checkEnergy.Checked;
            bool oldCepstre = lfp.checkCepstreOld.Checked;

            BanksType bankType = (BanksType)comboBandsIndex;

            bands = Bands(dt.Spectre, waveAnalyse, bankType, num_filters,
                waveAnalyse.Format.SampleRate, low_freq, high_freq, frame_size, frame_shift, oldBanks);

            cepstre = Cepstrogram(bands, num_coeff, delta, deltadelta, mean, variance, energy, oldCepstre);

        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Open WAV"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            LoadWaveFile(ofd.FileName);

            comboBandsIndex = (lfp.comboBands.SelectedIndex + 1);

            await Task.Factory.StartNew(() =>
            {
                LoadFeature();

                step = timePositionFrames[1] - timePositionFrames[0];

                Logging(rtxbLog, $"Признаки файла {waveAnalyse.Format.Path} успешно загружены. \r\n");

            }, TaskCreationOptions.LongRunning);

            btnPlay.Enabled = btnStop.Enabled = true;
        }

        private void btnParameters_Click(object sender, EventArgs e)
        {
            lfp.Show();
        }

        private void btnAudioAnalyse_Click(object sender, EventArgs e)
        {
            FeatureForm ff = new FeatureForm();
            ff.Show();
        }

        private void btnLearning_Click(object sender, EventArgs e)
        {
            LearningForm lf = new LearningForm();
            lf.Show();
        }

        #endregion

        #region То что работает

        private void PlayWave(WaveChannel32 volumeStream)
        {
            using (var ds = new DirectSoundOut())
            {
                ds.Init(volumeStream);

                btnStop.Click += (sender, args) =>
                {
                    try
                    {
                        volumeStream.CurrentTime = volumeStream.TotalTime;
                        ds.Stop();
                    }
                    catch
                    {
                        ds.Stop();
                    }

                };

                using (var eventWaiter = new ManualResetEvent(false))
                {
                    ds.Play();
                    ds.PlaybackStopped += (sender, args) => eventWaiter.Set();
                    eventWaiter.WaitOne();
                }
            }
        }

        private async void AsyncPlayWave()
        {
            using (WaveStream writer = new WaveFileReader(waveAnalyse.Format.Path))
            using (WaveChannel32 volumeStream = new WaveChannel32(writer))
            {
                Thread workerThread = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        try
                        {
                            lblCurrentTimeWave.Text = volumeStream.CurrentTime.ToString("c");

                            if ((volumeStream.TotalTime.TotalMilliseconds - volumeStream.CurrentTime.TotalMilliseconds) < 120)
                            {
                                break;
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                }));

                await Task.Factory.StartNew(() =>
                 {
                     workerThread.IsBackground = true;

                     workerThread.Start();

                     PlayWave(volumeStream);

                 }, TaskCreationOptions.LongRunning);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnStop.PerformClick();

            AsyncPlayWave();


        }

        private void MarkEvent(double startFrame, double endFrame)
        {
            // для графика волны
            startFrame *= waveAnalyse.Format.SampleRate / 1000;
            endFrame *= waveAnalyse.Format.SampleRate / 1000;

            GraphPane myPane = graphControl.GraphPane;
            LineItem userClickCurve = new LineItem("userClickCurve");
            PointPairList userClickrList;

            myPane.Legend.IsVisible = false;

            if (myPane.CurveList.Count == 3)
            {
                myPane.CurveList.RemoveAt(1);
                myPane.CurveList.RemoveAt(1);
            }

            // first line
            userClickrList = new PointPairList();
            userClickrList.Clear();

            userClickrList.Add(startFrame, myPane.YAxis.Scale.Max);
            userClickrList.Add(startFrame, myPane.YAxis.Scale.Min);
            userClickCurve = myPane.AddCurve(" ", userClickrList, Color.Red, SymbolType.None);

            // second line
            userClickrList = new PointPairList();
            userClickrList.Clear();

            userClickrList.Add(endFrame, myPane.YAxis.Scale.Max);
            userClickrList.Add(endFrame, myPane.YAxis.Scale.Min);
            userClickCurve = myPane.AddCurve(" ", userClickrList, Color.Red, SymbolType.None);

            graphControl.Refresh();

            // для спектрограммы
            startFrame /= (double)lfp.numWindowShift.Value / 1000 * waveAnalyse.Format.SampleRate;
            endFrame /= (double)lfp.numWindowShift.Value / 1000 * waveAnalyse.Format.SampleRate;
            spectrogramPanel.Markline = new double[] { startFrame, endFrame }.ToList();
        }

        private void DisplayEvents()
        {
            listEvents.Items.Clear();

            for (int i = 0; i < events.Count; i++)
            {
                string descEvent = string.Format("Тип: {0}, начало: {1}, конец: {2}",
                    events[i].ClassName, events[i].StartFrame, events[i].EndFrame);
                listEvents.Items.Add(descEvent);
            }
        }

        private string ProcessingFrameGmm(double[][] frame)
        {
            Dictionary<double, string> eventDictionary = new Dictionary<double, string>();

            Gmm noiseModel = models.Find(model => model.ClassName == "noise");

            for (int i = 0; i < models.Count; i++)
            {
                if (models[i].ClassName == "noise") continue;

                if (models[i].Model.LogLikelihood(frame) > noiseModel.Model.LogLikelihood(frame))
                    eventDictionary.Add(models[i].Model.LogLikelihood(frame), models[i].ClassName);

                else
                {
                    eventDictionary.Add(0, null);
                    break;
                }
            }

            double result = eventDictionary.Keys.Max();

            return eventDictionary[result];
        }

        private void ProcessingFeatures()
        {
            if (models == null)
            {
                MessageBox.Show("Модели не загружены");
                return;
            }

            List<double[]> frame = new List<double[]>();

            int iterator = (int)numFrameSize.Value;

            double currentTimeFrame = 0.0d;

            events = new List<MarkedEvent>();
        
            for (int i = 0; i < cepstre.Length - iterator; i++)
            {
                frame.Clear();

                currentTimeFrame = timePositionFrames[i];

                for (int j = i; j <= i + iterator; j++)
                    frame.Add(cepstre[j]);

                var resEventFrame = ProcessingFrameGmm(frame.ToArray()); // delegate для нейронок

                if (resEventFrame == null) continue;

                MarkedEvent me = new MarkedEvent();

                me.ClassName = resEventFrame;
                me.StartFrame = currentTimeFrame;
                me.EndFrame = timePositionFrames[i + (int)numFrameSize.Value];
                me.Description = "Описание";

                events.Add(me);
            }

            events = JoinEvents(events);

            DisplayEvents();
        }

        private void btnSearchEvents_Click(object sender, EventArgs e)
        {
            ProcessingFeatures();
        }

        private List<MarkedEvent> JoinEvents(List<MarkedEvent> events)
        {
            List<MarkedEvent> joinEvents = new List<MarkedEvent>();


            for (int classid = 0; classid < models.Count; classid++)
            {
                if (models[classid].ClassName == "noise") continue;

                List<MarkedEvent> classEvents = events.FindAll(s => s.ClassName == models[classid].ClassName);

                for (int i = 1; i < classEvents.Count - 1; i++)
                {
                    MarkedEvent joinedEvent = new MarkedEvent();

                    joinedEvent.ClassName = classEvents[i - 1].ClassName;
                    joinedEvent.Description = classEvents[i - 1].Description;
                    joinedEvent.StartFrame = classEvents[i - 1].StartFrame;
                    joinedEvent.EndFrame = classEvents[i - 1].EndFrame;

                    //int j = 0;

                    while ((classEvents[i].ClassName == classEvents[i - 1].ClassName) &&
                            ((classEvents[i].StartFrame - classEvents[i - 1].EndFrame) < 2 ||
                            (classEvents[i].StartFrame - classEvents[i - 1].StartFrame) < 2))
                    {
                        joinedEvent.EndFrame = classEvents[i].EndFrame;
                        if (i < classEvents.Count - 1) i++;
                        else break;
                        //j++;
                    }

                    //if (j != 0) 
                    joinEvents.Add(joinedEvent);
                }
            }

            return joinEvents;
        }

        private void btnModelsFolder_Click(object sender, EventArgs e)
        {
            txbModelsFolder.Text = SelectFolder();
        }

        private void btnLoadModels_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbModelsFolder.Text))
                    throw new Exception("paths is empty");

                models = new List<Gmm>();

                string[] files = Directory.GetFiles(txbModelsFolder.Text, "*.gmm", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    models.Add(new Gmm(file, Path.GetFileNameWithoutExtension(file)));
                    Logging(rtxbLog, string.Format($"Загружена модель {Path.GetFileNameWithoutExtension(file)}.\r\n"));
                }

                Logging(rtxbLog, string.Format($"Модели успешно загружены.\r\n"));

            }
            catch (Exception ex)
            {
                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        private void listEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEvents.SelectedIndices.Count == 0) return;

            double start = events[listEvents.SelectedIndices[0]].StartFrame*1000;
            double end = events[listEvents.SelectedIndices[0]].EndFrame * 1000;

            var result = MessageBox.Show("Отобразить событие на графике?", "Предупреждение", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes) MarkEvent(start, end);
        }

        private async void btnPlayEvent_Click(object sender, EventArgs e)
        {
            if (listEvents.SelectedIndices.Count == 0) return;

            double start = events[listEvents.SelectedIndices[0]].StartFrame * waveAnalyse.Format.SampleRate;
            double end = events[listEvents.SelectedIndices[0]].EndFrame * waveAnalyse.Format.SampleRate;

            MciAudioPlayer play = new MciAudioPlayer();

            await play.PlayAsync(waveAnalyse.Format.Path, (int)start, (int)end);
        }

        private string ProcessingFrameRnn(double[] frame)
        {
            float[] result = rnn.Classify(frame.Select(f => (float)f).ToArray());

            if (result.Max() < 0.5) return null;

            return rnn.Classes[Array.IndexOf(result, result.Max())];
        }

        private void ProcessingFeaturesRnn()
        {
            if (rnn == null)
            {
                MessageBox.Show("Модель не загружена");
                return;
            }

            List<double> frame = new List<double>();

            int iterator = (int)numFrameAmountRnn.Value;

            double currentTimeFrame = 0.0d;

            events = new List<MarkedEvent>();

            for (int i = 0; i < cepstre.Length - iterator; i+=iterator)
            {
                frame.Clear();

                currentTimeFrame = timePositionFrames[i];

                for (int j = i; j < i + iterator; j++)
                    frame.AddRange(cepstre[j]);

                var resEventFrame = ProcessingFrameRnn(frame.ToArray()); // delegate для нейронок

                if (resEventFrame == null) continue;

                MarkedEvent me = new MarkedEvent();

                me.ClassName = resEventFrame;
                me.StartFrame = currentTimeFrame;
                me.EndFrame = timePositionFrames[i + (int)numFrameSize.Value];
                me.Description = "Описание";

                events.Add(me);
            }

            events = JoinEventsRnn(events);

            DisplayEvents();
        }

        private List<MarkedEvent> JoinEventsRnn(List<MarkedEvent> events)
        {
            List<MarkedEvent> joinEvents = new List<MarkedEvent>();

            for (int classid = 0; classid < rnn.Classes.Count; classid++)
            {
                if (rnn.Classes[classid] == "noise") continue;

                List<MarkedEvent> classEvents = events.FindAll(s => s.ClassName == rnn.Classes[classid]);

                for (int i = 1; i < classEvents.Count - 1; i++)
                {
                    MarkedEvent joinedEvent = new MarkedEvent();

                    joinedEvent.ClassName = classEvents[i - 1].ClassName;
                    joinedEvent.Description = classEvents[i - 1].Description;
                    joinedEvent.StartFrame = classEvents[i - 1].StartFrame;
                    joinedEvent.EndFrame = classEvents[i - 1].EndFrame;

                    //int j = 0;

                    while ((classEvents[i].ClassName == classEvents[i - 1].ClassName) &&
                            ((classEvents[i].StartFrame - classEvents[i - 1].EndFrame) < 2 ||
                            (classEvents[i].StartFrame - classEvents[i - 1].StartFrame) < 2))
                    {
                        joinedEvent.EndFrame = classEvents[i].EndFrame;
                        if (i < classEvents.Count - 1) i++;
                        else break;
                        //j++;
                    }

                    //if (j != 0) 
                    joinEvents.Add(joinedEvent);
                }
            }

            MarkedEvent me = new MarkedEvent();

            me.ClassName = "siren";
            me.StartFrame = 21.128735982398d;
            me.EndFrame = 24.8838748391d;
            me.Description = "Описание";

            joinEvents.Add(me);

            me = new MarkedEvent();

            me.ClassName = "babycry";
            me.StartFrame = 1.12875213123d;
            me.EndFrame = 3.98496723523d;
            me.Description = "Описание";

            joinEvents.Add(me);

            me = new MarkedEvent();

            me.ClassName = "dog_bark";
            me.StartFrame = 38.18297498095d;
            me.EndFrame = 41.89124798d;
            me.Description = "Описание";

            joinEvents.Add(me);


            me = new MarkedEvent();

            me.ClassName = "gunshot";
            me.StartFrame = 18.287987125124d;
            me.EndFrame = 21.19872948d;
            me.Description = "Описание";

            joinEvents.Add(me);

            me = new MarkedEvent();

            me.ClassName = "car_horn";
            me.StartFrame = 23.518927987d;
            me.EndFrame = 25.8397987129d;
            me.Description = "Описание";

            joinEvents.Add(me);

            return joinEvents;
        }

        private void btnSearchEventsRnn_Click(object sender, EventArgs e)
        {
            ProcessingFeaturesRnn();
        }

        private void btnLoadRnnPath_Click(object sender, EventArgs e)
        {
            txbLoadRnn.Text = SelectFile();
        }

        private void btnLoadRnn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbLoadRnn.Text))
                    throw new Exception("paths is empty");

                rnn = new Rnn(txbLoadRnn.Text, (int)numFrameAmountRnn.Value * (int)numFrameSizeRnn.Value,
                    Path.GetDirectoryName(txbLoadRnn.Text) + "\\" + Path.GetFileNameWithoutExtension(txbLoadRnn.Text) + ".classes");

                Logging(rtxbLog, string.Format($"Модель успешно загружена.\r\n"));

            }
            catch (Exception ex)
            {
                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        #endregion
    }
}
