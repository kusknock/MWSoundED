using Accord.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Filtering;
using MathNet.Filtering.IIR;
using System.Numerics;

namespace MWSoundED.Classes
{
    public enum BanksType // тип банка фильров 
    {
        Mel = 1,
        Gammatone = 2
    };

    class MelBands
    {
        private double[][] spectrogram; // mel spectrogramm

        public double[][] Spectrogram { get { return spectrogram; } }

        private double[][] filters;

        public double[][] Filters { get { return filters; } }

        private int numberFilters, sampleRate, windowSize, frameCount;

        private double minFreq, maxFreq;

        /// <summary>
        /// Вычисление мел спектрограммы. Реализация через функции в классе. 
        /// </summary>
        /// <param name="spectre">Спектр сигнала.</param>
        /// <param name="n_filter">Кол-во гребенок фильтров.</param>
        /// <param name="s_rate">Частота дискретизации.</param>
        /// <param name="min_freq">Минимальная частота мел-шкалы.</param>
        /// <param name="max_freq">Максимальная частота мел-шкалы.</param>
        /// <param name="log">Логарифмирование бэндов.</param>
        public MelBands(double[][] spectre, int n_filter, int s_rate, int min_freq, int max_freq, bool old)
        {
            numberFilters = n_filter; // количество фильтров 
            sampleRate = s_rate; // частота дискретизации
            frameCount = spectre.Length; // количество фреймов
            windowSize = spectre[0].Length; // длина фрейма (windowSize / 2 + 1)

            minFreq = min_freq; // минимальная частота
            maxFreq = max_freq; // максимальная частота

            if (numberFilters < 24)
                throw new Exception("invalid value number filters");

            if(old) spectrogram = ProcessOld(spectre); // вычисление коэффициентов
            else spectrogram = Process(spectre); // вычисление коэффициентов
        }

        private double[][] ProcessOld(double[][] spectre) // вычисление признаков 
        {
            // инициализация матрицы бэндов
            double[][] bands = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                bands[i] = new double[numberFilters];

            // инициализация матрицы фильтров
            filters = GetMelFilterBanks();

            for (int i = 0; i < numberFilters; i++)
            {
                for (int k = 0; k < frameCount; k++)
                {
                    // применение фильтров к спектру
                    for (int j = 0; j < windowSize; j++)
                        bands[k][i] += filters[i][j] * spectre[k][j];
                }
            }

            return bands;
        }

        private double[][] GetMelFilterBanks() // получение матрицы фильтров 
        {
            double[][] filterBank = new double[numberFilters][];
            for (int i = 0; i < numberFilters; i++)
                filterBank[i] = new double[windowSize];

            double maxMelf, deltaMelf;
            double lowFreq, mediumFreq, highFreq, currentFreq;

            maxMelf = LinToMelFreq(maxFreq);
            deltaMelf = maxMelf / (numberFilters + 1);

            lowFreq = MelToLinFreq(minFreq);
            mediumFreq = MelToLinFreq(deltaMelf);
            highFreq = 0;

            for (int i = 0; i < numberFilters; i++)
            {
                highFreq = MelToLinFreq(deltaMelf * (i + 2));

                for (int j = 0; j < windowSize; j++)
                {
                    currentFreq = (j * 1.0 / (windowSize - 1) * (maxFreq));

                    if ((currentFreq >= lowFreq) && (currentFreq <= mediumFreq))
                        filterBank[i][j] = 2 * (currentFreq - lowFreq) / (mediumFreq - lowFreq);
                    else if ((currentFreq >= mediumFreq) && (currentFreq <= highFreq))
                        filterBank[i][j] = 2 * (highFreq - currentFreq) / (highFreq - mediumFreq);
                    else
                        filterBank[i][j] = 0;
                }

                lowFreq = mediumFreq;
                mediumFreq = highFreq;
            }

            return filterBank;
        }

        private double[][] Process(double[][] spectre) // вычисление признаков 
        {
            // инициализация матрицы бэндов
            double[][] bands = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                bands[i] = new double[numberFilters];

            //расчет бэндов
            var filterBands = UniformBands();

            // инициализация матрицы фильтров
            filters = GetMelFilterBanks(filterBands);

            for (int i = 0; i < numberFilters; i++)
            {
                for (int k = 0; k < frameCount; k++)
                {
                    // применение фильтров к спектру
                    for (int j = 0; j < windowSize; j++)
                        bands[k][i] += filters[i][j] * spectre[k][j];
                }
            }

            return bands;
        }

        private Tuple<double, double, double>[] UniformBands() // расчет бэндов фильтров 
        {
            if (minFreq < 0)
            {
                minFreq = 0;
            }
            if (maxFreq <= minFreq)
            {
                maxFreq = sampleRate / 2.0;
            }

            var startingFrequency = LinToMelFreq(minFreq);

            var frequencyTuples = new Tuple<double, double, double>[numberFilters];

            var newResolution = (LinToMelFreq(maxFreq) - LinToMelFreq(minFreq)) / (numberFilters + 1);

            var frequencies = Enumerable.Range(0, numberFilters + 2)
                                        .Select(i => MelToLinFreq(startingFrequency + i * newResolution))
                                        .ToArray();

            for (var i = 0; i < numberFilters; i++)
            {
                frequencyTuples[i] = new Tuple<double, double, double>
                    (frequencies[i], frequencies[i + 1], frequencies[i + 2]);
            }


            return frequencyTuples;
        }

        private double[][] GetMelFilterBanks(Tuple<double, double, double>[] frequencies) // получение матрицы фильтров
        {
            var herzResolution = (1+(windowSize - 1) * 2) / (double)sampleRate;

            var left = frequencies.Select(f => (int)Math.Floor(f.Item1 * herzResolution)).ToArray();
            var center = frequencies.Select(f => (int)Math.Floor(f.Item2 * herzResolution)).ToArray();
            var right = frequencies.Select(f => (int)Math.Floor(f.Item3 * herzResolution)).ToArray();

            var filterCount = frequencies.Length;
            var filterBank = new double[filterCount][];

            for (var i = 0; i < filterCount; i++)
            {
                filterBank[i] = new double[windowSize];

                for (var j = left[i]; j < center[i]; j++)
                {
                    filterBank[i][j] = (float)(j - left[i]) / (center[i] - left[i]);
                }
                for (var j = center[i]; j < right[i]; j++)
                {
                    filterBank[i][j] = (float)(right[i] - j) / (right[i] - center[i]);
                }
            }

            return filterBank;
        }

        private static double LinToMelFreq(double herz) // преобразование частоты в шкалу мел 
        {
            return 1127.01048 * Math.Log(herz / 700 + 1);

            //return 1125 * Math.Log((1 + herz / 700), 10);
        }

        private static double MelToLinFreq(double mel) // преобразование мел шкалы в частоты
        {
            return (Math.Exp(mel / 1127.01048) - 1) * 700;

            //return (Math.Pow(10, mel / 1125) - 1) * 700;
        }
    }

    class GammatoneBands
    {
        private double[][] spectrogram;

        public double[][] Spectrogram { get { return spectrogram; } }

        private double[][] filters;

        public double[][] Filters { get { return filters; } }

        private int numberFilters, sampleRate, windowSize, frameCount;

        private double minFreq, maxFreq;

        // fast method
        public GammatoneBands(double[][] spectre, int n_filter, int s_rate, int min_freq, int max_freq)
        {
            numberFilters = n_filter; // количество фильтров 
            sampleRate = s_rate; // частота дискретизации
            frameCount = spectre.Length; // количество фреймов
            windowSize = spectre[0].Length; // длина фрейма (windowSize / 2 + 1)

            minFreq = min_freq; // минимальная частота
            maxFreq = max_freq; // максимальная частота

            if (numberFilters < 24)
                throw new Exception("invalid value number filters");

            spectrogram = Process(spectre); // вычисление коэффициентов
        }

        private double[][] GetGammatoneFilterBanks()
        {
            if (minFreq < 0)
            {
                minFreq = 0;
            }
            if (maxFreq <= minFreq)
            {
                maxFreq = sampleRate / 2.0;
            }

            const double earQ = 9.26449;
            const double minBw = 24.7;
            const double bw = earQ * minBw;
            const int order = 1;

            var t = 1.0 / sampleRate;

            var frequencies = new double[numberFilters];
            for (var i = numberFilters; i > 0; i--)
            {
                frequencies[i - 1] =
                    -bw + Math.Exp(i * (-Math.Log(maxFreq + bw) + Math.Log(minFreq + bw)) / numberFilters) * (maxFreq + bw);
            }

            var ucirc = new Complex[windowSize];
            for (var i = 0; i < ucirc.Length; i++)
            {
                ucirc[i] = Complex.Exp((2 * Complex.ImaginaryOne * i * Math.PI) / ((windowSize - 1) * 2));
            }

            var rootPos = Math.Sqrt(3 + Math.Pow(2, 1.5));
            var rootNeg = Math.Sqrt(3 - Math.Pow(2, 1.5));

            var erbFilterBank = new double[numberFilters][];
            for (var i = 0; i < numberFilters; i++)
            {
                erbFilterBank[i] = new double[windowSize];
            }

            for (var i = 0; i < numberFilters; i++)
            {
                var cf = frequencies[i];
                var erb = Math.Pow(Math.Pow(cf / earQ, order) + Math.Pow(minBw, order), 1.0 / order);
                var b = 1.019 * 2 * Math.PI * erb;
                var gTord = 4;


                var theta = 2 * cf * Math.PI * t;
                var itheta = Complex.Exp(2 * Complex.ImaginaryOne * theta);

                var a0 = t;
                var b1 = -2 * Math.Cos(theta) / Math.Exp(b * t);
                var b2 = Math.Exp(-2 * b * t);

                var common = -t * Math.Exp(-b * t);

                var k1 = Math.Cos(theta) + rootPos * Math.Sin(theta);
                var k2 = Math.Cos(theta) - rootPos * Math.Sin(theta);
                var k3 = Math.Cos(theta) + rootNeg * Math.Sin(theta);
                var k4 = Math.Cos(theta) - rootNeg * Math.Sin(theta);

                var a11 = common * k1;
                var a12 = common * k2;
                var a13 = common * k3;
                var a14 = common * k4;

                double[] zros = new double[] { -a11 / t, -a12 / t, -a13 / t, -a14 / t }; // fast

                var gainArg = Complex.Exp(Complex.ImaginaryOne * theta - b * t);

                var gain = Complex.Abs(
                                    (itheta - gainArg * k1) *
                                    (itheta - gainArg * k2) *
                                    (itheta - gainArg * k3) *
                                    (itheta - gainArg * k4) *
                                    Complex.Pow(t * Math.Exp(b * t) / (-1.0 / Math.Exp(b * t) + 1 + itheta * (1 - Math.Exp(b * t))), 4.0));



                for (int k = 0; k < windowSize; k++)
                {
                    erbFilterBank[(numberFilters - 1) - i][k] = (float)((Math.Pow(t, gTord) / gain) *
                        Complex.Abs(ucirc[k] - zros[0]) * Complex.Abs(ucirc[k] - zros[1]) *
                        Complex.Abs(ucirc[k] - zros[2]) * Complex.Abs(ucirc[k] - zros[3])) *
                        (float)Math.Pow(Complex.Abs((gainArg - ucirc[k]) *
                        (new Complex(gainArg.Real, -gainArg.Imaginary) - ucirc[k])), -gTord);
                }
            }

            return erbFilterBank;
        }

        private double[][] Process(double[][] spectre)
        {
            // инициализация матрицы бэндов
            double[][] bands = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                bands[i] = new double[numberFilters];

            // инициализация матрицы фильтров
            filters = GetGammatoneFilterBanks();

            for (int i = 0; i < numberFilters; i++)
            {
                for (int k = 0; k < frameCount; k++)
                {
                    // применение фильтров к спектру
                    for (int j = 0; j < windowSize; j++)
                        bands[k][i] += filters[i][j] * spectre[k][j];
                }
            }

            return bands;
        }

        //accurate method
        public GammatoneBands(WaveReader wave, int frame_shift, int frame_size, int n_filter, int s_rate, int min_freq, int max_freq)
        {
            numberFilters = n_filter; // количество фильтров 
            sampleRate = s_rate; // частота дискретизации

            minFreq = min_freq; // минимальная частота
            maxFreq = max_freq; // максимальная частота

            frameCount = 1 + (int)Math.Floor(((double)wave.Mono.Length -
                (frame_size / 1000f * sampleRate)) / (frame_shift / 1000f * sampleRate)); // количество фреймов

            if (numberFilters < 24)
                throw new Exception("invalid value number filters");

            spectrogram = Process(wave.Mono, (int)(frame_size / 1000f * sampleRate),
                (int)(frame_shift / 1000f * sampleRate)); // вычисление коэффициентов
        }

        private double[][] GetGammatoneBands(double[] signal)
        {
            if (minFreq < 0)
            {
                minFreq = 0;
            }
            if (maxFreq <= minFreq)
            {
                maxFreq = sampleRate / 2.0;
            }

            const double earQ = 9.26449;
            const double minBw = 24.7;
            const double bw = earQ * minBw;
            const int order = 1;

            var t = 1.0 / sampleRate;

            var length = signal.Length;

            var frequencies = new double[numberFilters];
            for (var i = numberFilters; i > 0; i--)
            {
                frequencies[i - 1] =
                    -bw + Math.Exp(i * (-Math.Log(maxFreq + bw) + Math.Log(minFreq + bw)) / numberFilters) * (maxFreq + bw);
            }

            var rootPos = Math.Sqrt(3 + Math.Pow(2, 1.5));
            var rootNeg = Math.Sqrt(3 - Math.Pow(2, 1.5));

            var erbFilterBank = new double[numberFilters][];

            for (var i = 0; i < numberFilters; i++)
            {
                var cf = frequencies[i];
                var erb = Math.Pow(Math.Pow(cf / earQ, order) + Math.Pow(minBw, order), 1.0 / order);
                var b = 1.019 * 2 * Math.PI * erb;

                var theta = 2 * cf * Math.PI * t;
                var itheta = Complex.Exp(2 * Complex.ImaginaryOne * theta);

                var a0 = t;
                var a2 = 0.0;
                var b0 = 1.0;
                var b1 = -2 * Math.Cos(theta) / Math.Exp(b * t);
                var b2 = Math.Exp(-2 * b * t);

                var common = -t * Math.Exp(-b * t);

                var k1 = Math.Cos(theta) + rootPos * Math.Sin(theta);
                var k2 = Math.Cos(theta) - rootPos * Math.Sin(theta);
                var k3 = Math.Cos(theta) + rootNeg * Math.Sin(theta);
                var k4 = Math.Cos(theta) - rootNeg * Math.Sin(theta);

                var a11 = common * k1;
                var a12 = common * k2;
                var a13 = common * k3;
                var a14 = common * k4;

                var gainArg = Complex.Exp(Complex.ImaginaryOne * theta - b * t);

                var gain = Complex.Abs(
                                    (itheta - gainArg * k1) *
                                    (itheta - gainArg * k2) *
                                    (itheta - gainArg * k3) *
                                    (itheta - gainArg * k4) *
                                    Complex.Pow(t * Math.Exp(b * t) / (-1.0 / Math.Exp(b * t) + 1 + itheta * (1 - Math.Exp(b * t))), 4.0));

                var filter1 = new OnlineIirFilter(new[] { a0 / gain, a11 / gain, a2 / gain, b0, b1, b2 });
                var filter2 = new OnlineIirFilter(new[] { a0, a12, a2, b0, b1, b2 });
                var filter3 = new OnlineIirFilter(new[] { a0, a13, a2, b0, b1, b2 });
                var filter4 = new OnlineIirFilter(new[] { a0, a14, a2, b0, b1, b2 });

                var ir = new double[length];
                ir = (double[])signal.Clone();
                //ir[0] = 1.0; // check

                var ir1 = new double[length];
                var ir2 = new double[length];
                var ir3 = new double[length];
                var ir4 = new double[length];

                ir1 = filter1.ProcessSamples(ir);
                ir2 = filter2.ProcessSamples(ir1);
                ir3 = filter3.ProcessSamples(ir2);
                ir4 = filter4.ProcessSamples(ir3);

                erbFilterBank[(numberFilters - 1) - i] = ir4.Select(s => s * s).ToArray(); // с учетом возведения в квадрат

                //check
                //var kernel = DiscreteTransform.ConvertDoubleToComplex(ir4, ir4.Length);
                //var fft = DiscreteTransform.FourierInTime(kernel, true);
                //erbFilterBank[i] = DiscreteTransform.Spectrum(fft, false, DiscreteTransform.SpectrumType.Magnitude)
                //    .Select(s => 20 * Math.Log10(s)).ToArray();
            }

            return erbFilterBank;
        }

        private double[][] Process(double[] signal, int frameSize, int frameShift)
        {
            double[][] sourceBands = GetGammatoneBands(signal);

            // инициализация матрицы бэндов
            double[][] bands = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                bands[i] = new double[numberFilters];

            filters = GetGammatoneFilterBanks();

            for (int i = 0; i < frameCount; i++)
            {
                for (int k = 0; k < numberFilters; k++)
                {
                    double mean = 0f;

                    for (int j = 0; j < frameSize; j++)
                        mean += sourceBands[k][i * frameShift + j];

                    bands[i][k] = Math.Sqrt(mean / frameSize);
                }
            }

            return bands;
        }
    }

    class Cepstre
    {
        private double[][] features; // матрица признаков mfcc

        private double[][] featuresWithoutEnergy; // признаки без энергии

        private int numberCoefficients, numberFilters, frameCount;

        public double[][] WithoutEnergyFeatures { get { return featuresWithoutEnergy; } }

        public double[][] Features { get { return features; } }

        /// <summary>
        /// Вычисление кепстральных коэффициентов. Реализация через функции в классе. 
        /// После выполнения доступны свойства класса (различные вариации признаков).
        /// </summary>
        /// <param name="melbands">Бэнды фильтров.</param>
        /// <param name="n_coeff">Кол-во коэффициентов.</param>
        public Cepstre(double[][] melbands, int n_coeff, bool old = false)
        {
            numberFilters = melbands[0].Length; // количество фильтров 
            frameCount = melbands.Length; // количество фреймов
            numberCoefficients = n_coeff + 1; // длина вектора-признака

            if (numberCoefficients > 24 || numberCoefficients < 12 || numberCoefficients > numberFilters)
                throw new Exception("invalid value number filters or number coefficients");

            if (old) features = ProcessFeaturesOld(melbands); // вычисление коэффициентов
            else features = ProcessFeatures(melbands); // вычисление коэффициентов

            featuresWithoutEnergy = FeaturesWithoutEnergy(); // коэффициенты без энергий
        }

        private double[][] ProcessFeatures(double[][] melbands) // вычисление признаков 
        {
            // инициализация матрицы признаков
            double[][] coefficients = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                coefficients[i] = new double[numberCoefficients];

            // инициализация матрицы значений дискретного косинусного преобразования
            double[][] dctmat = GetDCTMatrix(22, numberCoefficients, numberFilters);

            // инициализация вектора лифтеринга
            double[] liftmat = Liftering(numberCoefficients);

            for (int k = 0; k < frameCount; k++)
            {
                for (int i = 0; i < numberCoefficients; i++)
                {
                    // применение дискретного косинусного преобразования
                    for (int j = 0; j < numberFilters; j++)
                        coefficients[k][i] += dctmat[i][j] * melbands[k][j];
                }
            }

            for (int i = 0; i < frameCount; i++)
                for (int j = 0; j < numberCoefficients; j++)
                    coefficients[i][j] *= liftmat[j];

            return coefficients;
        }

        private double[][] ProcessFeaturesOld(double[][] melbands) // вычисление признаков старая версия
        {
            // инициализация матрицы признаков
            double[][] coefficients = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                coefficients[i] = new double[numberCoefficients];

            // инициализация матрицы значений дискретного косинусного преобразования
            // old version
            double[][] dctmat = GetDCTMatrix(2, numberCoefficients, numberFilters);

            // инициализация вектора лифтеринга
            // old version
            double[] liftmat = Liftering(numberCoefficients - 1, denom: 0, type: 0);

            for (int k = 0; k < frameCount; k++)
            {
                for (int i = 0; i < numberCoefficients; i++)
                {
                    // применение дискретного косинусного преобразования
                    for (int j = 0; j < numberFilters; j++)
                        coefficients[k][i] += dctmat[i][j] * melbands[k][j];
                }
            }

            // old version
            for (int i = 0; i < frameCount; i++)
                for (int j = 1; j < numberCoefficients; j++)
                    coefficients[i][j] *= liftmat[j - 1];

            return coefficients;
        }

        private double[][] FeaturesWithoutEnergy() // получение признаков без первого коэффициента
        {
            double[][] withoutEnergy = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                withoutEnergy[i] = new double[numberCoefficients - 1];

            for (int i = 0; i < frameCount; i++)
                for (int j = 1; j < numberCoefficients; j++)
                    withoutEnergy[i][j - 1] = features[i][j]; // создание нового вектора без энергии

            return withoutEnergy;
        }

        private double[][] GetDCTMatrix(int type, int dctSize, int length) // получение значений дискретного косинусного преобразования 
        {
            double k = Math.PI / length;
            double w1 = 1.0 / (Math.Sqrt(length));
            double w2 = Math.Sqrt(2.0 / length);

            double[][] matrix = new double[dctSize][];
            for (int i = 0; i < dctSize; i++)
                matrix[i] = new double[length];

            for (int i = 0; i < dctSize; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (type == 0) // ортогональное
                    {
                        if (i == 0)
                            matrix[i][j] = w1 * Math.Cos(k * i * (j + 0.5d));
                        else
                            matrix[i][j] = w2 * Math.Cos(k * i * (j + 0.5d));
                    }
                    else if (type == 1) // не ортогональное
                    {
                        matrix[i][j] = Math.Cos(k * i * (j + 0.5d));
                    }
                    else if (type == 2) // wtf?
                    {
                        if (i == 0)
                            matrix[i][j] = 1;
                        else
                            matrix[i][j] = (2 * Math.Cos((0.5d * k * i * (2 * j + 1))));
                    }
                    else if(type == 22)
                    {
                        matrix[i][j] = Math.Cos((0.5d * k * i * (2 * j + 1)));
                    }
                    else
                    {
                        throw new Exception("invalid type of dct");
                    }
                }
            }

            return matrix;
        }

        private double[] Liftering(int length, int denom = 22, int type = 1) // лифтеринг 
        {
            if (denom == 0) denom = length;

            double[] matrix = new double[length];

            for (int i = 0; i < length; i++)
            {
                if (type == 0) matrix[i] = ((1.0 + 0.5 * denom * Math.Sin(Math.PI * (i + 1) / (denom))) / (1.0 + 0.5 * denom));
                else if (type == 1) matrix[i] = 1.0 + 0.5 * denom * Math.Sin(Math.PI * i / denom);
            }

            return matrix;
        }

        public static double[][] LogSpectre(double[][] bands, int type = 1) // логарифмирование спектра
        {
            int num_c = bands[0].Length; // количество фильтров 
            int num_f = bands.Length; // количество фреймов

            double[][] newBands = new double[num_f][];

            for (int i = 0; i < num_f; i++)
            {
                newBands[i] = new double[num_c];

                for (int j = 0; j < num_c; j++)
                {
                    //получение логарифма 
                    if (type == 0)
                    {
                        if (bands[i][j] < 1.0f / 100000.0f) { newBands[i][j] = Math.Log(1.0f / 100000.0f); }
                        else { newBands[i][j] = Math.Log(bands[i][j]); }
                    }
                    else if (type == 1)
                    {
                        newBands[i][j] = Math.Log10(bands[i][j] + float.Epsilon);
                    }
                }
            }

            return newBands;
        } 
    }

    class AccordMfcc
    {
        double[][] features; // матрица признаков mfcc

        double[][] featuresWithoutEnergy; // признаки без энергии

        int numberCoefficients, numberFilters, sampleRate, windowSize, frameCount, minFreq, maxFreq;

        public double[][] WithoutEnergyFeatures { get { return featuresWithoutEnergy; } }

        public double[][] Features { get { return features; } }

        /// <summary>
        /// Вычисление признаков MFCC. Реализация через библиотеки Accord.NET. 
        /// После выполнения доступны свойства класса (различные вариации признаков).
        /// </summary>
        /// <param name="signal">Отсчеты сигнала. Тип Accord.Audio.Signal.</param>
        /// <param name="n_coeff">Кол-во коэффициентов MFCC.</param>
        /// <param name="n_filter">Кол-во гребенок фильтров.</param>
        /// <param name="s_rate">Частота дискретизации.</param>
        /// <param name="size">Размер окна.</param>
        /// <param name="shift">Размер перекрытия.</param>
        /// <param name="min_freq">Минимальная частота мел-шкалы.</param>
        /// <param name="max_freq">Максимальная частота мел-шкалы.</param>
        /// <param name="durability">Длина сигнала, в пределах которого будут выделяться признаки.</param>
        public AccordMfcc(Signal signal, int n_coeff, int n_filter, int s_rate,
            int size, int shift, int min_freq, int max_freq, int durability = 0)
        {
            if (n_coeff > 24 || n_filter > 40 || n_coeff < 12 || n_filter < 24 || n_coeff > n_filter)
                throw new Exception("invalid value number filters or number coefficients");

            numberCoefficients = n_coeff + 1; // длина вектора-признака
            numberFilters = n_filter; // количество фильтров 
            sampleRate = s_rate; // частота дискретизации
            minFreq = min_freq; // минимальная частота
            maxFreq = max_freq; // максимальная частота

            // вычисление длины окна и перекрытия
            int frameShift = shift * (sampleRate / 1000); // размер перекрытия
            double frameSize = size / 1000f; // размер окна
            double nPowerTwo = Math.Ceiling(Math.Log(frameSize * sampleRate, 2)); // вычисление степени двойки от размера окна
            windowSize = (int)Math.Pow(2, nPowerTwo); // размер окна итоговый (степень двойки) (windowSize / 2 + 1)


            #region Изменение сигнала по длине (durability). Инициализация нового (newSignal)

            // получение новой длины сигнала (durability)
            int lengthSignal = durability * signal.SampleRate * signal.Channels;

            // проверка на превышение длины исходного сигнала
            if (lengthSignal > signal.Length || lengthSignal == 0) lengthSignal = signal.Length;

            // инициализация нового сигнала с новой длиной. Параметры совпадают с исходным сигналом
            Signal newSignal = new Signal(signal.Channels, lengthSignal, signal.SampleRate, signal.SampleFormat);

            for (int i = 0; i < newSignal.Length; i++)
            {
                // заполнение нового сигнала по каналам
                for (int channel = 0; channel < newSignal.Channels; channel++)
                    newSignal.SetSample(channel, i, signal.GetSample(channel, i));
            }

            #endregion

            MelFrequencyCepstrumCoefficient mfcc =
               new MelFrequencyCepstrumCoefficient(numberFilters, numberCoefficients, minFreq, maxFreq,
               0.97, sampleRate, frameShift, frameSize, windowSize);

            features = mfcc.Transform(newSignal).Select(x => x.Descriptor).ToArray();

            frameCount = features.Length; // количество фреймов

            featuresWithoutEnergy = FeaturesWithoutEnergy(); // коэффициенты без энергий
        }

        double[][] FeaturesWithoutEnergy() // получение признаков без первого коэффициента
        {
            double[][] withoutEnergy = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                withoutEnergy[i] = new double[numberCoefficients - 1];

            for (int i = 0; i < frameCount; i++)
                for (int j = 1; j < numberCoefficients; j++)
                    withoutEnergy[i][j - 1] = features[i][j]; // создание нового вектора без энергии

            return withoutEnergy;
        }
    }

    static class FeaturePostProcessing
    {
        public static void NormalizeMean(double[][] vectors)
        {
            if (vectors.Length < 2)
            {
                return;
            }

            var featureCount = vectors[0].Length;

            for (var i = 0; i < featureCount; i++)
            {
                var mean = vectors.Average(t => t[i]);

                foreach (var vector in vectors)
                {
                    vector[i] -= mean;
                }
            }
        }

        public static void NormalizeVariance(double[][] vectors, int bias = 1)
        {
            var n = vectors.Length;

            if (n < 2)
            {
                return;
            }

            var featureCount = vectors[0].Length;

            for (var i = 0; i < featureCount; i++)
            {
                var mean = vectors.Average(t => t[i]);
                var std = vectors.Sum(t => (t[i] - mean) * (t[i] - mean) / (n - bias));

                if (std < Math.Abs(1e-10))      // avoid dividing by zero
                {
                    std = 1;
                }

                foreach (var vector in vectors)
                {
                    vector[i] /= (float)Math.Sqrt(std);
                }
            }
        }

        public static void AddDeltas(double[][] vectors, double[][] previous = null,
            double[][] next = null, bool includeDeltaDelta = true)
        {
            if (previous == null)
            {
                previous = new double[][] { vectors[0], vectors[0] };
            }
            if (next == null)
            {
                next = new double[][] { vectors.Last(), vectors.Last() };
            }

            var featureCount = vectors[0].Length;

            var sequence = previous.Concat(vectors).Concat(next).ToArray();

            // deltas:

            const int N = 2;
            int M = 2 * Enumerable.Range(1, N).Sum(x => x * x);  // scaling in denominator

            for (var i = N; i < sequence.Length - N; i++)
            {
                var f = includeDeltaDelta ? new double[3 * featureCount] : new double[2 * featureCount];

                for (var j = 0; j < featureCount; j++)
                {
                    f[j] = vectors[i - N][j];
                }
                for (var j = 0; j < featureCount; j++)
                {
                    var num = 0.0d;
                    for (var n = 1; n <= N; n++)
                    {
                        num += n * (sequence[i + n][j] - sequence[i - n][j]);
                    }
                    f[j + featureCount] = num / M;
                }
                vectors[i - N] = f;

                sequence[i] = f;
            }

            if (!includeDeltaDelta) return;

            // delta-deltas:

            Array.Resize(ref sequence[0], vectors[0].Length);
            Array.Resize(ref sequence[1], vectors[0].Length);
            Array.Resize(ref sequence[vectors.Length + 2], vectors[0].Length);
            Array.Resize(ref sequence[vectors.Length + 3], vectors[0].Length);

            vectors[0].FastCopyTo(sequence[0], featureCount, featureCount, featureCount);
            vectors[0].FastCopyTo(sequence[1], featureCount, featureCount, featureCount);
            vectors.Last().FastCopyTo(sequence[vectors.Length + 2], featureCount, featureCount, featureCount);
            vectors.Last().FastCopyTo(sequence[vectors.Length + 3], featureCount, featureCount, featureCount);

            for (var i = N; i < sequence.Length - N; i++)
            {
                for (var j = 0; j < featureCount; j++)
                {
                    var num = 0.0d;
                    for (var n = 1; n <= N; n++)
                    {
                        num += n * (sequence[i + n][j + featureCount] -
                                    sequence[i - n][j + featureCount]);
                    }
                    vectors[i - N][j + 2 * featureCount] = num / M;
                }
            }
        }

        public static double[][] Concatenate(IList<double[]> source, params IList<double[]>[] vectors)
        {
            var vectorCount = vectors.Length;

            switch (vectorCount)
            {
                case 0:
                    throw new ArgumentException("Empty collection of feature vectors!");
                case 1:
                    return vectors.ElementAt(0).ToArray();
            }

            for(int i = 0; i<vectorCount; i++)
                for (int j = 0; j < vectors[i].Count; j++)
                    source.Add(vectors[i][j]);

            return source.ToArray();
        }
    }
}

