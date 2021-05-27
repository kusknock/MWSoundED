using Accord.IO;
using Accord.MachineLearning;
using Accord.Statistics.Distributions.Multivariate;
using CNTK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWSoundED.Classes
{
    class MarkedEvent
    {
        private double startFrame;

        private double endFrame;

        private string className;

        private string description;

        public double StartFrame { get { return startFrame; } set { startFrame = value; } }

        public double EndFrame { get { return endFrame; } set { endFrame = value; } }

        public string ClassName { get { return className; } set { className = value; } }

        public string Description { get { return description; } set { description = value; } }
    }

    class LearningSample 
    {
        private string fullPath;

        private string nameFile;

        private string classSample;

        private List<double[]> validSegments;

        public List<double[]> ValidSegments { get { return validSegments; } }

        public string NameFile { get { return nameFile; } }

        public string FullPath { get { return fullPath; } }

        public string ClassSample { get { return classSample; } }

        public LearningSample(string file_name, string class_name, List<double[]> segments)
        {
            fullPath = file_name;

            classSample = class_name;

            nameFile = Path.GetFileName(file_name);

            validSegments = segments;
        }
    }

    class Gmm
    {
        private GaussianMixtureModel gmm;

        private KMeans kmeans;

        private string className;

        private int k;

        public MultivariateMixture<MultivariateNormalDistribution> Model
        {
            get { return gmm.Gaussians.Model; }
        }

        public string ClassName { get { return className; } }

        public double LogLikelihood { get { return gmm.LogLikelihood; } }

        public Gmm(int components, bool useKMeans, string classType)
        {
            k = components;

            className = classType;

            if (useKMeans)
                kmeans = new KMeans(k);

            gmm = new GaussianMixtureModel(k);

            gmm.Options.Regularization = 1e-6;

            gmm.Options.Robust = true;
        }

        public Gmm(string path, string classType)
        {
            Load(path);

            className = classType;
        }

        public void Learn(double[][] data, IProgress<string> progress)
        {
            var watch = Stopwatch.StartNew();

            progress.Report("Процесс обучения алгоритма гауссовых смесей. \r\n");

            if (kmeans != null)
            {
                progress.Report($"Обучение алгоритма K-средних. \r\n");

                kmeans.Learn(data);

                progress.Report($"Обучение алгоритма K-средних завершено успешно. Количество итераций: {kmeans.Iterations} \r\n");

                gmm.Initialize(kmeans);
            }

            progress.Report($"Обучение алгоритма гауссовых смесей. \r\n");

            gmm.Learn(data);

            progress.Report($"Обучение алгоритма гауссовых смесей завершено успешно. Количество итераций: {gmm.Iterations} \r\n");

            watch.Stop(); // остановка таймера

            progress.Report($"Затраченое время: {watch.ElapsedMilliseconds / 1000f} с.\r\n");
        }

        public void Load(string path)
        {
            Serializer.Load(path, out gmm);
        }

        public void Save(string path)
        {
            Serializer.Save(gmm, path);
        }
    }

    class Rnn
    {
        private int inSize;
        private int outSize;

        private int cellsAmount;
        private int cellSize;

        private float dropout;

        private Function model;

        private DeviceDescriptor device = DeviceDescriptor.CPUDevice;

        private List<string> classes = new List<string>();

        public List<string> Classes { get { return classes; } }

        public Rnn(int inputSize, int outputSize, int cellsAm, int cellSi, float drop, string[] classArray)
        {
            inSize = inputSize;
            outSize = outputSize;
            cellsAmount = cellsAm;
            cellSize = cellSi;
            dropout = drop;
            classes = classArray.ToList();
        }

        public Rnn(string path, int inputSize, string pathClasses)
        {
            classes = File.ReadAllLines(pathClasses).ToList();

            inSize = inputSize;
            outSize = classes.Count;

            model = Function.Load(path, DeviceDescriptor.CPUDevice, ModelFormat.CNTKv2);
        }

        public void Learn(Dictionary<float[], float[][]> data, int epochs, int batchSize, IProgress<string> progress,
            float learninRate = 0.0005f, float timeConstant = 256f)
        {
            var feature = Variable.InputVariable(new int[] { inSize }, DataType.Float, "features", null, false /*isSparse*/);
            var label = Variable.InputVariable(new int[] { outSize }, DataType.Float, "label", new List<CNTK.Axis>() { CNTK.Axis.DefaultBatchAxis() }, false);

            model = Lstm.CreateModel(feature, outSize, cellsAmount, cellSize, device, dropout, "timeSeriesOutput");

            Function trainingLoss = CNTKLib.SquaredError(model, label, "squarederrorLoss");
            Function prediction = CNTKLib.SquaredError(model, label, "squarederrorEval");

            TrainingParameterScheduleDouble learningRatePerSample = new TrainingParameterScheduleDouble(learninRate, 1);
            TrainingParameterScheduleDouble momentumTimeConstant = CNTKLib.MomentumAsTimeConstantSchedule(timeConstant);

            IList<Learner> parameterLearners = new List<Learner>()
            {
                Learner.MomentumSGDLearner
                (
                    model.Parameters(),
                    learningRatePerSample,
                    momentumTimeConstant,
                    true
                )
            };

            var trainer = Trainer.CreateTrainer(model, trainingLoss, prediction, parameterLearners);

            progress.Report($"Обучение рекуррентной нейронной сети запущено. \r\n");

            for (int i = 1; i <= epochs; i++)
            {
                foreach (var miniBatchData in nextBatch(data, batchSize))
                {
                    var xValues = Value.CreateBatch(new NDShape(1, inSize), miniBatchData.X, device);
                    var yValues = Value.CreateBatch(new NDShape(1, outSize), miniBatchData.Y, device);

                    var batchData = new Dictionary<Variable, Value>();
                    batchData.Add(feature, xValues);
                    batchData.Add(label, yValues);  

                    trainer.TrainMinibatch(batchData, true, device);

                    progress.Report($"{i}-ая эпоха: значение функции потерь: {trainer.PreviousMinibatchLossAverage()}. \r\n");
                }
            }
        }

        public void Save(string path)
        {
            model.Save(path);

            File.WriteAllLines(Path.GetDirectoryName(path) + "\\" +
                Path.GetFileNameWithoutExtension(path) + ".classes", classes.ToArray());
        }

        public float[] Classify(float[] data)
        {
            var xValues = Value.CreateBatch(new NDShape(1, inSize), data, device);

            var fea = model.Arguments[0];
            var lab = model.Output;

            var inputDataMap = new Dictionary<Variable, Value>() { { fea, xValues } };
            var outputDataMap = new Dictionary<Variable, Value>() { { lab, null } };
            model.Evaluate(inputDataMap, outputDataMap, device);

            var oData = outputDataMap[lab].GetDenseData<float>(lab);

            return oData[0].ToArray();
        }

        private static IEnumerable<(float[] X, float[] Y)> nextBatch(Dictionary<float[], float[][]> dataset, int mMSize)
        {
            float[] asBatch(float[][] data, int start, int count)
            {
                var lst = new List<float>();
                for (int i = start; i < start + count; i++)
                {
                    if (i >= data.Length)
                        break;

                    lst.AddRange(data[i]);
                }
                return lst.ToArray();
            }

            float[] asBatchLabel(float[] label, int count)
            {
                float[] result = new float[label.Length * count];

                for (int batch = 0; batch < label.Length * count; batch += label.Length)
                    for (int i = 0; i < label.Length; i++)
                        result[i + batch] = label[i];

                return result;
            }

            foreach (var data in dataset)
            {
                for (int i = 0; i <= data.Value.Length; i += mMSize)
                {
                    var size = data.Value.Length - i;
                    if (size > 0 && size > mMSize)
                        size = mMSize;

                    var x = asBatch(data.Value, i, size);
                    var y = asBatchLabel(data.Key, size);

                    yield return (x, y);
                }
            }
        }
    }
}
