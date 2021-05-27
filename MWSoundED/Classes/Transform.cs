using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MWSoundED.Classes
{
    class DiscreteTransform
    {
        double[][] overlap;

        Complex[][] fourier;

        double[][] spectre;

        int frameCount, windowSize, frameSize;

        bool normalization;

        public Complex[][] Fourier { get { return fourier; } }

        public double[][] Spectre { get { return spectre; } }

        public DiscreteTransform(Overlapping frames, bool _normalization = true)
        {
            overlap = frames.Overlap; // амплитуды с перекрытием
            frameCount = frames.FrameCount; // количество фреймов
            windowSize = frames.WindowSize; // размер окна степень двойки
            frameSize = frames.FrameSize; // размер окна
            normalization = _normalization; // нормализация спектра
        }

        public enum TransformType // тип преобразования (прореживание по времени, прореживание по частоте)
        {
            InTime = 1,
            InFrequency = 2
        };

        public enum SpectrumType // тип спектра (энергетический, магнитудный)
        {
            Power = 1,
            Magnitude = 2
        };

        public static Complex[] FourierInTime(Complex[] frame, bool direct) // Фурье-преобразование с прореживанием по времени 
        {
            if (frame.Length == 1) return frame;
            var frameHalfSize = frame.Length >> 1; // frame.Length/2
            var frameFullSize = frame.Length;

            var frameOdd = new Complex[frameHalfSize];
            var frameEven = new Complex[frameHalfSize];
            for (var i = 0; i < frameHalfSize; i++)
            {
                var j = i << 1; // i = 2*j;
                frameOdd[i] = frame[j + 1];
                frameEven[i] = frame[j];
            }

            var spectrumOdd = FourierInTime(frameOdd, direct);
            var spectrumEven = FourierInTime(frameEven, direct);

            var arg = direct ? -2 * Math.PI / frameFullSize : 2 * Math.PI / frameFullSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[frameFullSize];

            for (var j = 0; j < frameHalfSize; j++)
            {
                spectrum[j] = spectrumEven[j] + omega * spectrumOdd[j];
                spectrum[j + frameHalfSize] = spectrumEven[j] - omega * spectrumOdd[j];
                omega *= omegaPowBase;
            }

            return spectrum;
        }

        public static Complex[] FourierInFrequency(Complex[] frame, bool direct) // Фурье-преобразование с прореживанием по частоте 
        {
            if (frame.Length == 1) return frame;
            var halfSampleSize = frame.Length >> 1; // frame.Length/2
            var fullSampleSize = frame.Length;

            var arg = direct ? -2 * Math.PI / fullSampleSize : 2 * Math.PI / fullSampleSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            var yTop = new Complex[halfSampleSize];
            var yBottom = new Complex[halfSampleSize];
            for (var i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }

            yTop = FourierInFrequency(yTop, direct);
            yBottom = FourierInFrequency(yBottom, direct);
            for (var i = 0; i < halfSampleSize; i++)
            {
                var j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }

        public static Complex[] ConvertDoubleToComplex(double[] frame, int frameSize) // конвертирование фрейма в комплексную форму 
        {
            Complex[] retComplex = new Complex[frameSize];

            for (int i = 0; i < frameSize; i++)
                retComplex[i] = new Complex(frame[i], 0);

            return retComplex;
        }

        public static double[] Spectrum(Complex[] frame, bool normalization, SpectrumType typeSpectrum) // функция вычисления спектра 
        {
            double[] spectrum = new double[frame.Length / 2 + 1];

            if (typeSpectrum == SpectrumType.Magnitude)
            {
                double[] magnitudeSpectrum = new double[frame.Length / 2 + 1];

                for (int i = 0; i < frame.Length / 2 + 1; i++)
                {
                    magnitudeSpectrum[i] = Math.Sqrt(frame[i].Real * frame[i].Real
                        + frame[i].Imaginary * frame[i].Imaginary);

                    if (normalization) magnitudeSpectrum[i] /= frame.Length;
                }

                spectrum = (double[])magnitudeSpectrum.Clone();
            }
            else if (typeSpectrum == SpectrumType.Power)
            {
                double[] powerSpectrum = new double[frame.Length / 2 + 1];

                for (int i = 0; i < frame.Length / 2 + 1; i++)
                {
                    powerSpectrum[i] = frame[i].Real * frame[i].Real
                        + frame[i].Imaginary * frame[i].Imaginary;

                    if (normalization) powerSpectrum[i] /= frame.Length;
                }

                spectrum = (double[])powerSpectrum.Clone();
            }

            return spectrum;
        }

        public void Process(TransformType t_type, SpectrumType s_type) // вычисление Фурье-преобразование 
        {
            fourier = new Complex[frameCount][];
            for (int index = 0; index < frameCount; index++)
                fourier[index] = new Complex[windowSize];

            spectre = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                spectre[index] = new double[windowSize / 2 + 1];

            Complex[] fftWindowComplex = new Complex[windowSize];

            for (int i = 0; i < frameCount; i++)
            {
                fftWindowComplex = ConvertDoubleToComplex(overlap[i], windowSize);

                switch ((int)t_type)
                {
                    case 1: fftWindowComplex = FourierInTime(fftWindowComplex, true); break;
                    case 2: fftWindowComplex = FourierInFrequency(fftWindowComplex, true); break;
                    default: throw new Exception("invalid type of transform");
                }

                for (int j = 0; j < windowSize; j++)
                    fourier[i][j] = fftWindowComplex[j];

                spectre[i] = Spectrum(fourier[i], normalization, s_type);
            }
        }

        /// <summary>
        /// Функция вычисления обратного преобразования Фурье
        /// Варианты использования:
        /// 1. Вместо косинусного преобразования
        /// 2. Для проверки
        /// </summary>
        public double[][] InverseFourierTransform(Complex[][] frames, int type) // обратное преобразование Фурье (для проверки) 
        {
            double[][] result;
            result = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                result[index] = new double[windowSize];

            Complex[] fftWindowComplex = new Complex[windowSize];

            for (int i = 0; i < frameCount; i++)
            {
                for (int j = 0; j < windowSize; j++)
                    frames[i][j] *= windowSize;

                switch (type)
                {
                    case 1: fftWindowComplex = FourierInTime(frames[i], false); break;
                    case 2: fftWindowComplex = FourierInFrequency(frames[i], false); break;
                    default: break;
                }

                for (int j = 0; j < frameSize; j++)
                    result[i][j] = fftWindowComplex[j].Real / Window.Hamming(j, windowSize);
            }

            return result;
        }

        /// <summary>
        /// Реализация быстрого преобразования Фурье
        /// Использовал ее для проверки
        /// Для использования внутри функции есть комментарий
        /// </summary>
        private void CalcFFT(double[] re, double[] im, int direction)
        {
            // Для использования реализации преобразования Фурье (CalcFFT)
            //double[] re = new double[windowSize];
            //double[] im = new double[windowSize];
            //CalFFT(re, im, -1);
            //re[j] = Window.Hamming(j, frameSize) * (short)(overlap[i][j] * 32768f);

            int n = re.Length;
            int bits = (int)Math.Round(Math.Log(n) / Math.Log(2), 0);

            if (n != (1 << bits))
                throw new Exception("fft data must be power of 2");

            int localN;
            int j = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    double temp = re[j];
                    re[j] = re[i];
                    re[i] = temp;
                    temp = im[j];
                    im[j] = im[i];
                    im[i] = temp;
                }

                int k = n / 2;

                while ((k >= 1) && (k - 1 < j))
                {
                    j = j - k;
                    k = k / 2;
                }

                j = j + k;
            }

            for (int m = 1; m <= bits; m++)
            {
                localN = 1 << m;
                double Wjk_r = 1;
                double Wjk_i = 0;
                double theta = (2 * Math.PI) / localN;
                double Wj_r = Math.Cos(theta);
                double Wj_i = direction * Math.Sin(theta);
                int nby2 = localN / 2;
                for (j = 0; j < nby2; j++)
                {
                    for (int k = j; k < n; k += localN)
                    {
                        int id = k + nby2;
                        double tempr = Wjk_r * re[id] - Wjk_i * im[id];
                        double tempi = Wjk_r * im[id] + Wjk_i * re[id];
                        re[id] = re[k] - tempr;
                        im[id] = im[k] - tempi;
                        re[k] += tempr;
                        im[k] += tempi;
                    }
                    double wtemp = Wjk_r;
                    Wjk_r = Wj_r * Wjk_r - Wj_i * Wjk_i;
                    Wjk_i = Wj_r * Wjk_i + Wj_i * wtemp;
                }
            }
        }

    }

    class Wavelets
    {
        public static class Haar
        {
            private const double w0 = 0.5;
            private const double w1 = -0.5;
            private const double s0 = 0.5;
            private const double s1 = 0.5;

            /// <summary>
            ///   Discrete Haar Wavelet Transform
            /// </summary>
            public static void FWT(double[] data)
            {
                double[] temp = new double[data.Length];

                int h = data.Length >> 1;
                for (int i = 0; i < h; i++)
                {
                    int k = (i << 1);
                    temp[i] = data[k] * s0 + data[k + 1] * s1;
                    temp[i + h] = data[k] * w0 + data[k + 1] * w1;
                }

                for (int i = 0; i < data.Length; i++)
                    data[i] = temp[i];
            }

            /// <summary>
            ///   Inverse Haar Wavelet Transform
            /// </summary>
            public static void IWT(double[] data)
            {
                double[] temp = new double[data.Length];

                int h = data.Length >> 1;
                for (int i = 0; i < h; i++)
                {
                    int k = (i << 1);
                    temp[k] = (data[i] * s0 + data[i + h] * w0) / w0;
                    temp[k + 1] = (data[i] * s1 + data[i + h] * w1) / s0;
                }

                for (int i = 0; i < data.Length; i++)
                    data[i] = temp[i];
            }
        }

        public static class CFT97
        {
            // Constants as used by Gregoire P.
            const double alpha = -1.586134342;
            const double beta = -0.05298011854;
            const double gamma = 0.8829110762;
            const double delta = 0.4435068522;
            const double zeta = 1.149604398;

            /// <summary>
            ///   Forward biorthogonal 9/7 wavelet transform
            /// </summary>
            public static void FWT97(double[] x)
            {
                int n = x.Length;

                // Predict 1
                for (int i = 1; i < n - 2; i += 2)
                    x[i] += alpha * (x[i - 1] + x[i + 1]);
                x[n - 1] += 2 * alpha * x[n - 2];

                // Update 1
                for (int i = 2; i < n; i += 2)
                    x[i] += beta * (x[i - 1] + x[i + 1]);
                x[0] += 2 * beta * x[1];

                // Predict 2
                for (int i = 1; i < n - 2; i += 2)
                    x[i] += gamma * (x[i - 1] + x[i + 1]);
                x[n - 1] += 2 * gamma * x[n - 2];

                // Update 2
                for (int i = 2; i < n; i += 2)
                    x[i] += delta * (x[i - 1] + x[i + 1]);
                x[0] += 2.0 * delta * x[1];

                // Scale
                for (int i = 0; i < n; i++)
                {
                    if ((i % 2) != 0)
                        x[i] *= (1 / zeta);
                    else x[i] /= (1 / zeta);
                }

                // Pack
                var tempbank = new double[n];
                for (int i = 0; i < n; i++)
                {
                    if ((i % 2) == 0)
                        tempbank[i / 2] = x[i];
                    else tempbank[n / 2 + i / 2] = x[i];
                }

                for (int i = 0; i < n; i++)
                    x[i] = tempbank[i];
            }

            /// <summary>
            ///   Inverse biorthogonal 9/7 wavelet transform
            /// </summary>
            public static void IWT97(double[] x)
            {
                int n = x.Length;

                // Unpack
                var tempbank = new double[n];
                for (int i = 0; i < n / 2; i++)
                {
                    tempbank[i * 2] = x[i];
                    tempbank[i * 2 + 1] = x[i + n / 2];
                }

                for (int i = 0; i < n; i++)
                    x[i] = tempbank[i];

                // Undo scale
                for (int i = 0; i < n; i++)
                {
                    if ((i % 2) != 0)
                        x[i] *= zeta;
                    else x[i] /= zeta;
                }

                // Undo update 2
                for (int i = 2; i < n; i += 2)
                    x[i] -= delta * (x[i - 1] + x[i + 1]);
                x[0] -= 2.0 * delta * x[1];

                // Undo predict 2
                for (int i = 1; i < n - 2; i += 2)
                    x[i] -= gamma * (x[i - 1] + x[i + 1]);
                x[n - 1] -= 2.0 * gamma * x[n - 2];

                // Undo update 1
                for (int i = 2; i < n; i += 2)
                    x[i] -= beta * (x[i - 1] + x[i + 1]);
                x[0] -= 2.0 * beta * x[1];

                // Undo predict 1
                for (int i = 1; i < n - 2; i += 2)
                    x[i] -= alpha * (x[i - 1] + x[i + 1]);
                x[n - 1] -= 2.0 * alpha * x[n - 2];

            }
        }
    }

    class Overlapping
    {
        double[][] overlap; // результат работы алгоритма

        List<double> timepos; // позиции фреймов во времени

        int sampleRate, freqPerMSec, frameSize,
            frameCount, frameShift, windowSize,
            durability, start;

        bool toShort, fillNull, preemphasis;

        double nPowerTwo, alpha;

        public double[][] Overlap { get { return overlap; } }

        public List<double> TimePosition { get { return timepos; } }

        public int FrameSize { get { return frameSize; } }

        public int FrameCount { get { return frameCount; } }

        public int WindowSize { get { return windowSize; } }

        public Overlapping(WaveReader wav, int size, int shift, double startValue = 0, double durability_size = 0, bool to_short = false, bool fill_null = true, bool pre = false, double a = 0.97)
        {
            preemphasis = pre;
            alpha = a; // коэффициент предобработки
            sampleRate = wav.Format.SampleRate; // частота дискретизации
            freqPerMSec = sampleRate / 1000; // частота в миллисекунде
            frameShift = shift * freqPerMSec; // размер перекрытия
            frameSize = size * freqPerMSec; // размер окна
            start = (int)(startValue * sampleRate); // начало валидного сегмента
            durability = (int)(durability_size * sampleRate); // ограничение по длительности звукозаписи
            toShort = to_short; // приведение типов
            fillNull = fill_null; // заполнение нулями
            if (start >= wav.Mono.Length) start = 0;
            if ((durability > wav.Mono.Length || durability_size == 0) && start == 0) durability = wav.Mono.Length; // проверка на выход за пределы файла
            frameCount = (durability - frameSize + frameShift) / frameShift; // количество блоков, которые укладываются за время аудиосигнала
            nPowerTwo = Math.Ceiling(Math.Log(frameSize, 2)); // вычисление степени двойки от размера окна
            windowSize = (int)Math.Pow(2, nPowerTwo); // размер окна итоговый (степень двойки)

            var amplitudes = durability != 0 && start != 0 ? wav.Mono.FastCopyFragment(durability, start) : wav.Mono;

            Process(amplitudes, frameCount, windowSize, frameSize, frameShift); // вычисление амплитуд с перекрытием
        }

        private void Process(double[] amplitudes, int frameCount, int windowSize, int frameSize, int frameShift)
        {
            if (preemphasis) Preemphasis(amplitudes, alpha);

            //инициализация массива амплитуд с перекрытием
            overlap = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                overlap[index] = new double[windowSize];

            timepos = new List<double>();

            int windowArraySize = 0; // результирующий размер 

            for (int i = 0; i < frameCount; i++) //заполнение результирующего массива с амплитудой и перекрытием
            {
                if (fillNull) windowArraySize = frameSize; // !power of 2
                else windowArraySize = windowSize; // power of 2

                timepos.Add((double)(i * frameShift) / sampleRate);

                for (int j = 0; j < windowArraySize; j++)
                {
                    if (i * frameShift + j >= amplitudes.Length) break;

                    overlap[i][j] = amplitudes[i * frameShift + j] * Window.Hamming(j, windowArraySize);

                    if (toShort) overlap[i][j] *= 32768f;
                }
            }
        }

        private static void Preemphasis(double[] amplitudes, double a)
        {
            double prevSample = 0;

            int length = amplitudes.Length;

            for (var k = 0; k < length; k++)
            {
                var y = amplitudes[k] - prevSample * a;
                prevSample = amplitudes[k];
                amplitudes[k] = y;
            }
        }
    }

    class Window
    {
        private const double Q = 0.5;

        public static double Rectangle(double n, double frameSize)
        {
            return 1;
        }

        public static double Gauss(double n, double frameSize)
        {
            var a = (frameSize - 1) / 2;
            var t = (n - a) / (Q * a);
            t = t * t;
            return Math.Exp(-t / 2);
        }

        public static double Hamming(double n, double frameSize)
        {
            return 0.54 - 0.46 * Math.Cos((2 * Math.PI * n) / (frameSize - 1)); // тут исправил frameSize на (frameSize - 1)
        }

        public static double Hann(double n, double frameSize)
        {
            return 0.5 * (1 - Math.Cos((2 * Math.PI * n) / (frameSize - 1)));
        }

        public static double BlackmannHarris(double n, double frameSize)
        {
            return 0.35875 - (0.48829 * Math.Cos((2 * Math.PI * n) / (frameSize - 1))) +
                   (0.14128 * Math.Cos((4 * Math.PI * n) / (frameSize - 1))) - (0.01168 * Math.Cos((4 * Math.PI * n) / (frameSize - 1)));
        }
    }

    class Distance
    {
        static public double calcDistance(double[] seq1, int seq1size, double[] seq2, int seq2size)
        {

            // Create diff matrix
            double[,] diffM = new double[seq1size, seq2size];


            for (int i = 0; i < seq1size; i++)
            {
                for (int j = 0; j < seq2size; j++)
                {
                    diffM[i, j] = Math.Abs(seq1[i] - seq2[j]);
                }
            }

            // Compute distance
            double distance = findDistance(seq1size, seq2size, diffM);

            return distance;
        }

        static double calcDistanceVector(double[] seq1, int seq1size,
                double[] seq2, int seq2size, int vectorSize)
        {

            int seq1sizeV = seq1size / vectorSize;
            int seq2sizeV = seq2size / vectorSize;

            // Create diff matrix
            double[,] diffM = new double[seq1sizeV, seq2sizeV];


            for (int i = 0; i < seq1sizeV; i++)
            {
                for (int j = 0; j < seq2sizeV; j++)
                {

                    // Calc distance between vectors
                    double distanceVector = 0f;
                    for (int k = 0; k < vectorSize; k++)
                    {
                        distanceVector += Math.Pow(seq1[i * vectorSize + k] - seq2[j * vectorSize + k], 2);
                    }

                    diffM[i, j] = (float)Math.Sqrt(distanceVector);
                }
            }

            // Compute distance
            double distance = findDistance(seq1sizeV, seq2sizeV, diffM);

            return distance;
        }

        static double findDistance(int seq1size, int seq2size, double[,] diffM)
        {

            // Create distance matrix (forward direction)
            double[,] pathM = new double[seq1size, seq2size];


            pathM[0, 0] = diffM[0, 0];
            for (int i = 1; i < seq1size; i++)
            {
                pathM[i, 0] = diffM[i, 0] + pathM[i - 1, 0];
            }
            for (int j = 1; j < seq2size; j++)
            {
                pathM[0, j] = diffM[0, j] + pathM[0, j - 1];
            }

            for (int i = 1; i < seq1size; i++)
            {
                for (int j = 1; j < seq2size; j++)
                {
                    if (pathM[i - 1, j - 1] < pathM[i - 1, j])
                    {
                        if (pathM[i - 1, j - 1] < pathM[i, j - 1])
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i - 1, j - 1];
                        }
                        else
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i, j - 1];
                        }
                    }
                    else
                    {
                        if (pathM[i - 1, j] < pathM[i, j - 1])
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i - 1, j];
                        }
                        else
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i, j - 1];
                        }
                    }
                }
            }

            // Find the warping path (backward direction)
            int warpSize = seq1size * seq2size;
            double[] warpPath = new double[warpSize];

            int warpPathIndex = 0;
            int iW = seq1size - 1, jW = seq2size - 1;

            warpPath[warpPathIndex] = pathM[iW, jW];

            do
            {
                if (iW > 0 && jW > 0)
                {

                    if (pathM[iW - 1, jW - 1] < pathM[iW - 1, jW])
                    {
                        if (pathM[iW - 1, jW - 1] < pathM[iW, jW - 1])
                        {
                            iW--;
                            jW--;
                        }
                        else
                        {
                            jW--;
                        }

                    }
                    else
                    {
                        if (pathM[iW - 1, jW] < pathM[iW, jW - 1])
                        {
                            iW--;
                        }
                        else
                        {
                            jW--;
                        }
                    }

                }
                else
                {
                    if (0 == iW)
                    {
                        jW--;
                    }
                    else
                    {
                        iW--;
                    }
                }

                warpPath[++warpPathIndex] = pathM[iW, jW];

            } while (iW > 0 || jW > 0);

            // Calculate path measure
            double distance = 0f;
            for (int k = 0; k < warpPathIndex + 1; k++)
            {
                distance += warpPath[k];
            }
            distance = distance / (warpPathIndex + 1);

            return distance;
        }

        static public double GetDistanceChebyshev(double[] features1, double[] features2)
        {
            int width = features1.Length > features2.Length ? features2.Length : features1.Length;

            double distance = 0.0d;

            for (int i = 0; i < width; i++)
            {
                var currentDistance = Math.Abs(features1[i] - features2[i]);

                distance = (currentDistance > distance) ? currentDistance : distance;
            }

            return distance;
        }

        static public double GetDistanceEuqlid(double[] features1, double[] features2)
        {
            int width = features1.Length > features2.Length ? features2.Length : features1.Length;

            double distance = 0.0d;

            for (int i = 0; i < width; i++)
            {
                var diff = features1[i] - features2[i];
                distance += diff * diff;
            }

            return (float)Math.Sqrt(distance);
        }
    }
}
