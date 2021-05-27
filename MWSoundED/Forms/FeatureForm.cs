using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MWSoundED.Classes;
using ZedGraph;

namespace MWSoundED
{
    public partial class FeatureForm : Form
    {
        private WaveReader waveAnalyse; // данные файла (.wav)

        private Overlapping overlapProcess; // второй этап (перекрывающиеся кадры)

        private DiscreteTransform transformProcess; // третий этап (дискретное преобразование «Фурье»)

        private MelBands melbands; // мел-спектрограмма

        private GammatoneBands gbands; // гамматон-спектрограмма

        private Cepstre cepstre; // кепстральные коэффициенты

        public FeatureForm()
        {
            InitializeComponent();

            InitializeGraph();

            comboBands.SelectedIndex = 0;
        }

        #region Интерфейс

        private void InitializeGraph()
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
            statusStrip.Items.Clear();

            waveAnalyse = new WaveReader(path);

            int sampleRate = waveAnalyse.Format.SampleRate;
            int channels = waveAnalyse.Format.Channels;
            int bits = waveAnalyse.Format.BitsPerSample;
            int duration = waveAnalyse.Format.Duration;
            string name = Path.GetFileName(waveAnalyse.Format.Path);

            string status = string.Format("Имя файла: {4}, Частота дискретизации: {0}, Каналов: {1}, Бит: {2}, Длительность: {3} сек.",
                sampleRate, channels, bits, duration, name);

            ToolStripLabel infoLabel = new ToolStripLabel() { Text = status };

            statusStrip.Items.Add(infoLabel);

            DisplayWaveGraph(waveAnalyse.Mono);

            int findedItems = comboGraph.FindStringExact("График волны");

            if (findedItems == -1)
                comboGraph.Items.Add("График волны");

            comboGraph.SelectedIndex = 0;

            groupDiscreteTransform.Enabled = true;

            groupBands.Enabled = false;

            groupBank.Enabled = false;

            groupCepstre.Enabled = false;

            btnSave.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Open WAV"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            LoadWaveFile(ofd.FileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRecorderForm_Click(object sender, EventArgs e)
        {
            Recorder recorder = new Recorder();

            if (recorder.ShowDialog() != DialogResult.OK)
                return;

            LoadWaveFile(recorder.OutWaveFileName);
        }

        private void comboGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGraph.Text == "График волны")
            {
                graphControl.Visible = true;
                spectrogramPanel.Visible = false;
                bandsPanel.Visible = false;
                featuresPanel.Visible = false;
            }
            else if (comboGraph.Text == "Спектрограмма")
            {
                graphControl.Visible = false;
                spectrogramPanel.Visible = true;
                bandsPanel.Visible = false;
                featuresPanel.Visible = false;
            }
            else if( comboGraph.Text == "Спектрограмма (мел или гамматон)")
            {
                graphControl.Visible = false;
                spectrogramPanel.Visible = false;
                bandsPanel.Visible = true;
                featuresPanel.Visible = false;
            }
            else if (comboGraph.Text == "Кепстральные коэффициенты")
            {
                graphControl.Visible = false;
                spectrogramPanel.Visible = false;
                bandsPanel.Visible = false;
                featuresPanel.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboGraph.Text == "График волны")
                return;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Feature file *.feature|*.feature",
                Title = "Save Feature"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            double[][] features = null;

            if (comboGraph.Text == "Спектрограмма")
                features = spectrogramPanel.Spectrogram.ToArray();

            else if (comboGraph.Text == "Спектрограмма (мел или гамматон)")
                features = bandsPanel.Spectrogram.ToArray();

            else if (comboGraph.Text == "Кепстральные коэффициенты")
                features = featuresPanel.Spectrogram.ToArray();

            using (var csvFile = new FileStream(sfd.FileName, FileMode.Create))
            {
                var serializer = new CsvFeatureSerializer(features);

                var task = serializer.SerializeAsync(csvFile);

                task.Wait();

                if (task.IsCompleted) MessageBox.Show("Сохранено успешно.");
            }
        }

        #endregion

        #region ОДПФ

        private void DisplaySpectrogram(WaveReader wave, int frameSize, int frameShift, double start, double durability, bool toShort, bool fillNull, bool preemphasis, double a)
        {
            // преобразование сигнала в массив перекрывающихся фреймов
            overlapProcess = new Overlapping(wave, frameSize, frameShift, startValue: start, durability_size: durability,
                to_short: toShort, fill_null: fillNull, pre: preemphasis, a: a); // to_short: true, fill_null: false (old version)

            // инициализация объекта дискретного преобразования
            transformProcess = new DiscreteTransform(overlapProcess);

            transformProcess.Process(DiscreteTransform.TransformType.InTime, DiscreteTransform.SpectrumType.Power); // преобразование Фурье массива фреймов

            spectrogramPanel.Spectrogram = Cepstre.LogSpectre(transformProcess.Spectre).ToList(); // отрисовка спектрограммы
        }

        private void btnFourier_Click(object sender, EventArgs e)
        {
            int frame_size, frame_shift;

            bool to_short, fill_null, preemph;

            double a = 0.0d, start = 0.0d, durability = 0.0d;

            frame_size = (int)numWindowSize.Value;
            frame_shift = (int)numWindowShift.Value;

            a = (double)numA.Value;

            durability = (double)numEndValue.Value - (double)numStartValue.Value;
            start = (double)numStartValue.Value;

            to_short = checkShort.Checked;
            fill_null = checkFillNull.Checked;
            preemph = checkPreemphasis.Checked;

            DisplaySpectrogram(waveAnalyse, frame_size, frame_shift, start, 
                durability, to_short, fill_null, preemph, a);

            int findedItems = comboGraph.FindStringExact("Спектрограмма");

            if (findedItems == -1)
                comboGraph.Items.Add("Спектрограмма");
        
            comboGraph.SelectedIndex = 1;

            groupBands.Enabled = true;
        }

        private async void btnPlaySegment_Click(object sender, EventArgs e)
        {
            // TODO (себе на будущее): 
            // Добавить возможность выбирать сегмент вручную, 
            // как я это делал в курсаче Зотина зимой 2019

            MciAudioPlayer play = new MciAudioPlayer();

            double start = (double)numStartValue.Value * waveAnalyse.Format.SampleRate;

            double end = (double)numEndValue.Value * waveAnalyse.Format.SampleRate;

            if (end == 0.0d) end = waveAnalyse.SourceSignal.Length;

            await play.PlayAsync(waveAnalyse.Format.Path, (int)start, (int)end);
        }

        #endregion

        #region Спектальное представление сигнала

        private void btnBands_Click(object sender, EventArgs e)
        {
            BanksType type;

            int num_filters, sample_rate, low_freq, high_freq, frame_shift, frame_size;

            bool old;

            type = (BanksType)(comboBands.SelectedIndex + 1);

            num_filters = (int)numFilters.Value;
            sample_rate = waveAnalyse.Format.SampleRate;
            low_freq = (int)numLowFrequency.Value;
            high_freq = (int)numUpFrequency.Value;

            frame_size = (int)numWindowSize.Value;
            frame_shift = (int)numWindowShift.Value;

            old = checkBanksOld.Checked;

            DisplayBands(type, num_filters, sample_rate, low_freq, high_freq, frame_size, frame_shift, old);

            int findedItems = comboGraph.FindStringExact("Спектрограмма (мел или гамматон)");

            if (findedItems == -1)
                comboGraph.Items.Add("Спектрограмма (мел или гамматон)");

            comboGraph.SelectedIndex = 2;

            groupBank.Enabled = true;

            groupCepstre.Enabled = true;
        }

        private void DisplayBands(BanksType type, int numFilters, int sampleRate, int lowFreq,
            int highFreq, int frameSize, int frameShift, bool old)
        {
            if (type == BanksType.Mel)
            {
                if (!old)
                {
                    melbands = new MelBands(transformProcess.Spectre, numFilters, sampleRate, lowFreq, highFreq, old);

                    bankPlot.Gain = 100;
                }
                else if (old)
                {
                    melbands = new MelBands(transformProcess.Spectre, numFilters, sampleRate, lowFreq, highFreq, old);

                    bankPlot.Gain = 50;
                }

                bandsPanel.Spectrogram = Cepstre.LogSpectre(melbands.Spectrogram).ToList();

                bankPlot.Groups = melbands.Filters;
            }
            else if (type == BanksType.Gammatone)
            {
                if (!old)
                {
                    gbands = new GammatoneBands(transformProcess.Spectre, numFilters, sampleRate, lowFreq, highFreq);

                    bankPlot.Gain = 100;
                }
                else if (old)
                {
                    gbands = new GammatoneBands(waveAnalyse, frameShift, frameSize, numFilters, sampleRate, lowFreq, highFreq);

                    bankPlot.Gain = 100;
                }

                bandsPanel.Spectrogram = Cepstre.LogSpectre(gbands.Spectrogram).ToList();

                bankPlot.Groups = gbands.Filters;
            }
        }

        #endregion

        #region Кепстральные коэффициенты

        private void btnCepstre_Click(object sender, EventArgs e)
        {
            int num_coeff;

            bool delta, deltadelta, mean, variance, old, energy;

            num_coeff = (int)numCoeffCepstre.Value;

            delta = checkDelta.Checked;
            deltadelta = checkDeltaDelta.Checked;

            mean = checkMean.Checked;
            variance = checkVariance.Checked;

            old = checkCepstreOld.Checked;

            energy = checkEnergy.Checked;

            DisplayCepstrogram(num_coeff, delta, deltadelta, mean, variance, energy, old);

            int findedItems = comboGraph.FindStringExact("Кепстральные коэффициенты");

            if (findedItems == -1)
                comboGraph.Items.Add("Кепстральные коэффициенты");

            comboGraph.SelectedIndex = 3;
        }

        private void DisplayCepstrogram(int numCoeff, bool delta, bool deltadelta, bool mean, bool variance, bool energy, bool old)
        {
            double[][] bandsSpectrogram = bandsPanel.Spectrogram.ToArray();

            cepstre = new Cepstre(bandsSpectrogram, numCoeff, old); // logSpectre type:0, old = true

            double[][] cepstreCoeff = null;

            if (energy) cepstreCoeff = cepstre.Features.ToArray();

            else cepstreCoeff = cepstre.WithoutEnergyFeatures.ToArray();

            if (mean) FeaturePostProcessing.NormalizeMean(cepstreCoeff);

            if (variance) FeaturePostProcessing.NormalizeVariance(cepstreCoeff);

            if (delta) FeaturePostProcessing.AddDeltas(cepstreCoeff, includeDeltaDelta: false);

            if (deltadelta) FeaturePostProcessing.AddDeltas(cepstreCoeff);

            featuresPanel.Spectrogram = cepstreCoeff.ToList();
        }

        #endregion

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                var video = txbPathVideo.Text;
                var audio = txbPathSaveWave.Text;

                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.FileName = string.Format("{0}\\MediaToolkit\\ffmpeg.exe", Environment.CurrentDirectory);

                process.StartInfo.Arguments = string.Format("-i \"{0}\" -acodec pcm_s16le -ar 16000 -ac 1 \"{1}\"", video, audio);

                //process.StartInfo.Arguments = string.Format("-i \"{0}\"  \"{1}\"", video, Path.Combine(audio, "test.wav"));

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Операция успешно завершена.");
                LoadWaveFile(txbPathSaveWave.Text);
            }
        }

        private void btnPathVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Video file *.mp4|*.mp4",
                Title = "Open Video"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            txbPathVideo.Text = ofd.FileName;
        }

        private void btnPathSaveWave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Wav file *.wav|*.wav",
                Title = "Save Wav"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            txbPathSaveWave.Text = sfd.FileName;
        }
    }
}
