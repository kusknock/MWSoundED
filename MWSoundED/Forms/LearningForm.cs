using MWSoundED.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keras.Models;
using Keras.Layers;
using Keras.Optimizers;
using Numpy;

namespace MWSoundED
{
    public partial class LearningForm : Form
    {
        Thread workerThread = null;

        private List<LearningSample> lsList = null;

        // --------------- Параметры парсинга ---------------

        private string pathCsv = string.Empty;

        private string pathLearnSamplesDirectory = string.Empty;

        private LearningFeatureParameters lfp = new LearningFeatureParameters();

        // --------------- Параметры обучения  ---------------

        List<string> classNames;

        BanksType bankType;

        string className;

        string pathSaveFeature;

        // TODO: если я когда-нибудь возьмусь это переделывать, 
        // необходимо в этой части сделать структуру 
        // {
        //      признаки(+сегменты) 
        //      название файла признаков
        // }
        // P.S. по-хорошему конечно всё переделать
        private List<List<double[]>> separateFeatures; // отдельные части признаков

        private List<string> stringSeparateFeatures;  // название признаков и их сегментов

        private double[][] features; // итоговая матрица признаков

        Gmm learnGmm;

        Rnn learnRnn;

        public LearningForm()
        {
            InitializeComponent();

            comboTypeFile.SelectedIndex = 0;
        }

        #region Helpers

        private void EnableControls(bool enable)
        {
            if (InvokeRequired) // если функция выполняется в другом потоке
            {
                Invoke((Action)(() => EnableControls(enable)));
            }
            else // здесь выключение/включение элементов во время работы в потоке
            {
                groupLearning.Enabled = enable;
                groupConcatFeatures.Enabled = enable;
            }
        }

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

        private void ProgressBarValue(ProgressBar control, double progress)
        {
            if (control.InvokeRequired)
            {
                Invoke((Action)(() => ProgressBarValue(control, progress)));
            }
            else
            {
                control.Value = (int)progress;
            }
        }

        private void ComboBoxData(ComboBox control, object data)
        {
            if (control.InvokeRequired)
            {
                Invoke((Action)(() => ComboBoxData(control, data)));
            }
            else
            {
                control.DataSource = data;
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

        #endregion

        #region Парсинг

        private void ParseFilesFromDirectoryCsv()
        {
            try
            {
                var watch = Stopwatch.StartNew(); // таймер для замера времени работы алгоритма

                lsList = new List<LearningSample>();

                classNames = new List<string>();

                if (string.IsNullOrEmpty(pathLearnSamplesDirectory) || string.IsNullOrEmpty(pathCsv))
                    throw new Exception("paths is empty");

                string[] files = Directory.GetFiles(pathLearnSamplesDirectory, "*.wav", SearchOption.AllDirectories);

                Logging(rtxbLog, $"Успешно загружены файлы из директории: {pathLearnSamplesDirectory}. \n");

                using (StreamReader reader = new StreamReader(pathCsv))
                {
                    Logging(rtxbLog, $"Успешно загружен файл CSV: {pathCsv}. \n");

                    Logging(rtxbLog, $"Операция получения обучающей выборки начата. \n");

                    reader.ReadLine(); // первая строка с названиями колонок

                    while (!reader.EndOfStream)
                    {
                        string[] vs = reader.ReadLine().Split(',');

                        string file = Array.Find(files, f => Path.GetFileName(f) == vs[0]);

                        double start = double.Parse(vs[2].Replace('.', ','));

                        double end = double.Parse(vs[3].Replace('.', ','));

                        List<double[]> seg = new List<double[]>();

                        seg.Add(new double[] { start, end });

                        LearningSample ls = new LearningSample(file, vs[7], seg);

                        if (classNames.FindLast(f => f == vs[7]) == null)
                            classNames.Add(vs[7]);

                        lsList.Add(ls);

                        ProgressBarValue(progressBarParse, 100 * ((double)lsList.Count / files.Length));
                    }
                }

                ComboBoxData(comboClasses, classNames);

                watch.Stop(); // остановка таймера

                EnableControls(true);

                Logging(rtxbLog, $"Получено файлов {lsList.Count}. \n");

                Logging(rtxbLog, string.Format($"Затраченое время: {watch.ElapsedMilliseconds / 1000f} с.\r\n"));

                Logging(rtxbLog, $"Операция получения обучающей успешно завершена. \n");
            }
            catch (Exception ex)
            {
                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }

        }

        private void ParseFilesFromDirectoryYaml()
        {
            try
            {
                lsList = new List<LearningSample>();

                classNames = new List<string>();

                if (string.IsNullOrEmpty(pathLearnSamplesDirectory))
                    throw new Exception("path is empty");

                string[] files = Directory.GetFiles(pathLearnSamplesDirectory, "*.yaml", SearchOption.AllDirectories);

                Logging(rtxbLog, $"Успешно загружены файлы из директории: {pathLearnSamplesDirectory}. \n");

                Logging(rtxbLog, $"Операция получения обучающей выборки начата. \n");

                var watch = Stopwatch.StartNew(); // таймер для замера времени работы алгоритма

                foreach (string yaml in files)
                {
                    using (StreamReader reader = new StreamReader(yaml))
                    {
                        List<double[]> vs = new List<double[]>();

                        while (!reader.EndOfStream)
                        {
                            if (reader.ReadLine() != "valid_segments:") continue;
                            else break;
                        }

                        while (!reader.EndOfStream)
                        {
                            string[] strStart = reader.ReadLine().Split(' ');
                            string[] strEnd = reader.ReadLine().Split(' ');

                            double start = double.Parse(strStart[2].Replace('.', ','));
                            double end = double.Parse(strEnd[3].Replace('.', ','));

                            vs.Add(new double[] { start, end });
                        }

                        string file = string.Format("{0}\\{1}.wav", Path.GetDirectoryName(yaml), Path.GetFileNameWithoutExtension(yaml));

                        string className = Path.GetDirectoryName(yaml).Split('\\').Last();

                        if (classNames.FindLast(f => f == className) == null)
                            classNames.Add(className);

                        LearningSample ls = new LearningSample(file, className, vs);

                        lsList.Add(ls);

                        ProgressBarValue(progressBarParse, 100 * ((double)lsList.Count / files.Length));
                    }
                }

                watch.Stop(); // остановка таймера

                ComboBoxData(comboClasses, classNames);

                EnableControls(true);

                Logging(rtxbLog, $"Операция успешно завершена. \n");

                Logging(rtxbLog, $"Получено файлов {lsList.Count}. \n");

                Logging(rtxbLog, string.Format($"Затраченое время: {watch.ElapsedMilliseconds / 1000f} с.\r\n"));
            }
            catch (Exception ex)
            {
                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        private void comboTypeFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTypeFile.Text == "CSV")
            {
                txbCsvFile.Enabled = true;
                lblCsvFile.Enabled = true;
                btnCsvFile.Enabled = true;
            }
            else
            {
                txbCsvFile.Enabled = false;
                lblCsvFile.Enabled = false;
                btnCsvFile.Enabled = false;
            }
        }

        private void btnLearnFolder_Click(object sender, EventArgs e)
        {
            txbLearnFolder.Text = SelectFolder();

            pathLearnSamplesDirectory = txbLearnFolder.Text;
        }

        private void btnCsvFile_Click(object sender, EventArgs e)
        {
            txbCsvFile.Text = SelectFile();

            pathCsv = txbCsvFile.Text;
        }

        private void btnGetLearningFiles_Click(object sender, EventArgs e)
        {
            try
            {
                EnableControls(false);

                if (comboTypeFile.Text == "YAML")
                {
                    workerThread = new Thread(new ThreadStart(ParseFilesFromDirectoryYaml));

                    workerThread.IsBackground = true;

                    workerThread.Start();
                }

                else if (comboTypeFile.Text == "CSV")
                {
                    workerThread = new Thread(new ThreadStart(ParseFilesFromDirectoryCsv));

                    workerThread.IsBackground = true;

                    workerThread.Start();
                }

            }
            catch (Exception ex)
            {
                if (workerThread != null) workerThread.Abort();

                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        #endregion

        #region Конкатенация признаков

        private double[][] Spectrogram(WaveReader wave, int frameSize, int frameShift, double start, double durability,
            bool toShort, bool fillNull, bool preemphasis, double a)
        {
            // преобразование сигнала в массив перекрывающихся фреймов
            Overlapping overlapProcess = new Overlapping(wave, frameSize, frameShift, startValue: start, durability_size: durability,
                to_short: toShort, fill_null: fillNull, pre: preemphasis, a: a); // to_short: true, fill_null: false (old version)

            // инициализация объекта дискретного преобразования
            DiscreteTransform transformProcess = new DiscreteTransform(overlapProcess);

            transformProcess.Process(DiscreteTransform.TransformType.InTime, DiscreteTransform.SpectrumType.Power); // преобразование Фурье массива фреймов

            return transformProcess.Spectre;
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

        private List<double[]> GetFeatures(WaveReader waveAnalyse, double start, double durability)
        {
            // --------------- Данные WAV и STFT ---------------

            int frame_size = (int)lfp.numWindowSize.Value;
            int frame_shift = (int)lfp.numWindowShift.Value;

            bool to_short = lfp.checkShort.Checked;
            bool fill_null = lfp.checkFillNull.Checked;
            bool preemph = lfp.checkPreemphasis.Checked;

            double a = (double)lfp.numA.Value;

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

            // --------------- Признаки ---------------

            Logging(rtxbLog, string.Format($"Получение спектрограммы файла.\r\n"));

            double[][] spectre = Spectrogram(waveAnalyse, frame_size, frame_shift,
                start, durability, to_short, fill_null, preemph, a);

            Logging(rtxbLog, string.Format($"Применение банка фильтров к спектрограмме.\r\n"));

            double[][] bands = Bands(spectre, waveAnalyse, bankType, num_filters,
                waveAnalyse.Format.SampleRate, low_freq, high_freq, frame_size, frame_shift, oldBanks);

            Logging(rtxbLog, string.Format($"Получение кепстральных коэффициентов.\r\n"));

            double[][] cepstre = Cepstrogram(bands, num_coeff, delta, deltadelta, mean, variance, energy, oldCepstre);

            if (rbtnCepstre.Checked)
                return cepstre.ToList();

            return bands.ToList();
        }

        private void GetFeaturesFromLearningSamples()
        {
            try
            {
                Logging(rtxbLog, $"Операция объединения обучающей выборки начата. \n");

                var watch = Stopwatch.StartNew(); // таймер для замера времени работы алгоритма

                separateFeatures = new List<List<double[]>>();

                stringSeparateFeatures = new List<string>();

                int lsListCount = lsList.Count(s => s.ClassSample == className); //lsList.Count / 2;

                lsListCount /= 10;

                for (int i = 0, j = 0; i < lsList.Count; i++)
                {
                    try
                    {
                        if (lsList[i].ClassSample != className)
                        {
                            continue;
                        }

                        if (j == lsListCount) break;

                        j++;

                        ProgressBarValue(progressBarConcat, 100 * ((double)j / lsListCount));

                        Logging(rtxbLog, string.Format($"Открытие файла {lsList[i].NameFile}. ({j} из {lsListCount})\r\n"));

                        WaveReader waveAnalyse = new WaveReader(lsList[i].FullPath);

                        for (int segment = 0; segment < lsList[i].ValidSegments.Count; segment++)
                        {
                            Logging(rtxbLog, string.Format($"Обработка сегмента {segment + 1} из {lsList[i].ValidSegments.Count}. \r\n"));

                            double start = lsList[i].ValidSegments[segment][0];

                            double durability = lsList[i].ValidSegments[segment][1] - lsList[i].ValidSegments[segment][0];

                            var feat = GetFeatures(waveAnalyse, start, durability);
                        
                            separateFeatures.Add(feat);

                            stringSeparateFeatures.Add($"{Path.GetFileNameWithoutExtension(lsList[i].FullPath)}_{segment}"); // костыль!!!!!!!!!1111111
                        }

                        Logging(rtxbLog, string.Format($"Обработка файла {lsList[i].NameFile} завершена.\r\n"));
                    }
                    catch (Exception ex)
                    {
                        Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));

                        continue;
                    }
                }

                watch.Stop(); // остановка таймера

                List<double[]> source = new List<double[]>();

                FeaturePostProcessing.Concatenate(source, separateFeatures.ToArray());

                features = source.ToArray();

                EnableControls(true);

                Logging(rtxbLog, $"Операция успешно завершена. \n");

                Logging(rtxbLog, string.Format($"Затраченое время: {watch.ElapsedMilliseconds / 1000f} с.\r\n"));
            }
            catch (Exception ex)
            {
                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        private void btnFeatureParameters_Click(object sender, EventArgs e)
        {
            lfp.Show();
        }

        private void btnConcatFeatures_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsList == null || lsList.Count == 0)
                {
                    MessageBox.Show("Обучающая выборка не заполнена");
                    return;
                }

                EnableControls(false);

                bankType = (BanksType)(lfp.comboBands.SelectedIndex + 1);

                className = comboClasses.Text;

                workerThread = new Thread(new ThreadStart(GetFeaturesFromLearningSamples));

                workerThread.IsBackground = true;

                workerThread.Start();
            }
            catch (Exception ex)
            {
                if (workerThread != null) workerThread.Abort();

                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }


        }

        #endregion

        #region Сохранение признаков

        private void SaveFeatures()
        {
            try
            {
                var watch = Stopwatch.StartNew();

                string fileName = string.Format("{0}\\{1}.feature", pathSaveFeature, className);

                Logging(rtxbLog, $"Сохранение файлов с признаками объектов класса {className}\r\n");

                using (var csvFile = new FileStream(fileName, FileMode.Create))
                {
                    var serializer = new CsvFeatureSerializer(features);

                    var task = serializer.SerializeAsync(csvFile);

                    task.Wait();

                    if (task.IsCompleted)
                        Logging(rtxbLog, $"Сохранение объединенных признаков класса {className} завершено. \r\n");
                }

                for (int i = 0; i < separateFeatures.Count; i++)
                {
                    fileName = string.Format("{0}\\{1}\\{2}.feature", pathSaveFeature, className, stringSeparateFeatures[i]);

                    if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                        Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                    using (var csvFile = new FileStream(fileName, FileMode.Create))
                    {
                        var serializer = new CsvFeatureSerializer(separateFeatures[i].ToArray());

                        var task = serializer.SerializeAsync(csvFile);

                        task.Wait();

                        if (task.IsCompleted)
                            Logging(rtxbLog, $"Сохранение файла {stringSeparateFeatures[i]} признаков класса {className} завершено. \r\n");
                    }
                }

                watch.Stop(); // остановка таймера

                Logging(rtxbLog, string.Format($"Затраченое время: {watch.ElapsedMilliseconds / 1000f} с.\r\n"));

                EnableControls(true);
            }
            catch (Exception ex)
            {
                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        private void btnSaveLearningSample_Click(object sender, EventArgs e)
        {
            txbSaveLearningSample.Text = SelectFolder();

            pathSaveFeature = txbSaveLearningSample.Text;
        }

        private void btnSaveFeatures_Click(object sender, EventArgs e)
        {
            try
            {
                if (separateFeatures == null || features == null)
                {
                    MessageBox.Show("Признаки не загружены");
                    return;
                }

                EnableControls(false);

                workerThread = new Thread(new ThreadStart(SaveFeatures));

                workerThread.IsBackground = true;

                workerThread.Start();

            }
            catch(Exception ex)
            {
                EnableControls(true);

                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        #endregion

        #region Обучение GMM

        private string SaveFileModel(string name)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Gmm files *.gmm|*.gmm",
                Title = "Save model",
                InitialDirectory = Environment.CurrentDirectory,
                FileName = txbClass.Text + ".gmm"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return string.Empty;

            return sfd.FileName;
        }

        private void checkLoadDataFromFile_CheckedChanged(object sender, EventArgs e)
        {
            txbFeatureFilePath.Enabled = checkLoadDataFromFile.Checked;
            checkNoiseModel.Checked = !checkLoadDataFromFile.Checked;
            btnFeatureFilePath.Enabled = checkLoadDataFromFile.Checked;
        }

        private void checkNoiseModel_CheckedChanged(object sender, EventArgs e)
        {
            txbNoiseModel.Enabled = checkNoiseModel.Checked;
            btnNoiseModel.Enabled = checkNoiseModel.Checked;
            checkLoadDataFromFile.Checked = !checkNoiseModel.Checked;
        }

        private void btnFeatureFilePath_Click(object sender, EventArgs e)
        {
            txbFeatureFilePath.Text = SelectFile();
        }

        private void btnSaveModelPath_Click(object sender, EventArgs e)
        {
            txbSaveModelPath.Text = SaveFileModel(txbClass.Text);
        }

        private async void btnStartLearnGmm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbClass.Text))
            {
                MessageBox.Show("Введите название класса событий");
                return;
            }

            List<double[]> selectFileFeature = new List<double[]>();

            string featureFile = txbFeatureFilePath.Text;

            string noiseFileFeatures = txbNoiseModel.Text;

            await Task.Factory.StartNew(() =>
            {
                if (checkLoadDataFromFile.Checked)
                {
                    using (StreamReader reader = new StreamReader(featureFile))
                    {
                        Logging(rtxbLog, $"Успешно загружен файл c признаками: {featureFile}. \n");

                        Logging(rtxbLog, $"Операция получения обучающей выборки начата. \n");

                        reader.ReadLine(); // первая строка с названиями колонок

                        while (!reader.EndOfStream)
                        {
                            string[] vs = reader.ReadLine().Split(',');

                            double[] fv = vs.Select(s => double.Parse(s.Replace('.', ','))).ToArray();

                            selectFileFeature.Add(fv);
                        }

                        Logging(rtxbLog, $"Операция получения обучающей выборки завершена. \n");
                    }
                }
                else if(checkNoiseModel.Checked)
                {
                    string[] files = Directory.GetFiles(noiseFileFeatures, "*.feature", SearchOption.AllDirectories);

                    foreach (string noise in files)
                    {
                        using (StreamReader reader = new StreamReader(noise))
                        {
                            Logging(rtxbLog, $"Успешно загружен файл c признаками: {noise}. \n");

                            Logging(rtxbLog, $"Операция получения обучающей выборки начата. \n");

                            reader.ReadLine(); // первая строка с названиями колонок

                            while (!reader.EndOfStream)
                            {
                                string[] vs = reader.ReadLine().Split(',');

                                double[] fv = vs.Select(s => double.Parse(s.Replace('.', ','))).ToArray();

                                selectFileFeature.Add(fv);
                            }

                            Logging(rtxbLog, $"Операция получения обучающей выборки завершена. \n");
                        }
                    }
                }
                else
                {
                    if (features == null)
                    {
                        MessageBox.Show("Признаки не загружены");
                        return;
                    }

                    selectFileFeature = features.ToList();
                }
            }, TaskCreationOptions.LongRunning);

            int k = (int)numK.Value;

            learnGmm = new Gmm(k, checkKMeans.Checked, txbClass.Text);

            IProgress<string> progress = new Progress<string>(str => Logging(rtxbLog, str));

            await Task.Factory.StartNew(() => learnGmm.Learn(selectFileFeature.ToArray(), progress), TaskCreationOptions.LongRunning);

            learnGmm.Save(txbSaveModelPath.Text);
        }

        private void btnNoiseModel_Click(object sender, EventArgs e)
        {
            txbNoiseModel.Text = SelectFolder();
        }

        #endregion

        #region Обучение RNN

        private void btnFeaturesFolder_Click(object sender, EventArgs e)
        {
            txbFeaturesFolder.Text = SelectFolder();
        }

        private async void btnLearnRnn_Click(object sender, EventArgs e)
        {
            float[] outputRnn(int i, int size)
            {
                float[] result = new float[size];

                result[i] = 0.99f;

                return result;
            }

            try
            {
                if (string.IsNullOrEmpty(txbFeaturesFolder.Text)) return;

                Dictionary<float[], float[][]> features = new Dictionary<float[], float[][]>();

                List<float[]> featureList = new List<float[]>();

                string[] files = Directory.GetFiles(txbFeaturesFolder.Text, "*.feature", SearchOption.TopDirectoryOnly);

                int inputSize = (int)numInFrames.Value * (int)numFrameSizeRnn.Value;

                int outputSize = files.Length;

                int batchSize = (int)numBatchSize.Value;

                int cellsAmount = (int)numLstmCells.Value;

                int cellSize = (int)numLstmCellSize.Value;

                float dropout = (float)numDropout.Value;

                float learningRate = (float)numLearningRate.Value;

                int epochs = (int)numIterations.Value;

                learnRnn = new Rnn(inputSize, outputSize, cellsAmount, cellSize, dropout, 
                    files.Select(f => Path.GetFileNameWithoutExtension(f)).ToArray());

                Logging(rtxbLog, $"Успешно загружены файлы из директории: {txbFeaturesFolder.Text}. \n");

                Logging(rtxbLog, $"Операция получения обучающей выборки начата. \n");

                await Task.Factory.StartNew(() =>
                {
                    foreach (string feature in files)
                    {
                        using (StreamReader reader = new StreamReader(feature))
                        {
                            featureList.Clear();

                            Logging(rtxbLog, $"Успешно загружен файл c признаками: {feature}. \n");

                            Logging(rtxbLog, $"Операция получения обучающей выборки начата. \n");

                            reader.ReadLine(); // первая строка с названиями колонок

                            List<float> frames = new List<float>();

                            int i = 0;

                            while (!reader.EndOfStream)
                            {
                                string[] vs = reader.ReadLine().Split(',');

                                float[] fv = vs.Select(s => float.Parse(s.Replace('.', ','))).ToArray();

                                if (i < (int)numInFrames.Value)
                                {
                                    frames.AddRange(fv);
                                    i++;
                                }
                                else
                                {
                                    featureList.Add(frames.ToArray());
                                    frames.Clear();
                                    i = 0;
                                }
                            }

                            features.Add(outputRnn(Array.FindIndex(files, f => f == feature), files.Length), featureList.ToArray());

                            Logging(rtxbLog, $"Операция получения обучающей выборки из файла {feature} завершена. \n");
                        }
                    }
                });

                IProgress<string> progress = new Progress<string>(str => Logging(rtxbLog, str));

                await Task.Factory.StartNew(() => learnRnn.Learn(features, epochs, batchSize, progress, learningRate));

                learnRnn.Save(txbSaveModelRnn.Text);

                Logging(rtxbLog, $"Операция успешно завершена. \n");
            }
            catch (Exception ex)
            {
                Logging(rtxbLog, string.Format($"Ошибка: {ex.Message}\r\n"));
            }
        }

        private void btnFolderSaveModelRnn_Click(object sender, EventArgs e)
        {
            string SaveRnnModel()
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Rnn files *.rnn|*.rnn",
                    Title = "Save model",
                    InitialDirectory = Environment.CurrentDirectory,
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return string.Empty;

                return sfd.FileName;
            }

            txbSaveModelRnn.Text = SaveRnnModel();
        }

        #endregion

        #region Обучение CNN

        private async void button3_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        private void btnCnnFeaturePath_Click(object sender, EventArgs e)
        {
            txbCnnFeature.Text = SelectFolder();
        }
        #endregion
    }
}
