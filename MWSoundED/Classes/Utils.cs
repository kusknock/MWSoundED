using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWSoundED.Classes
{
    public static class MemoryOperationExtensions
    {
        public static float[] ToFloats(this IEnumerable<double> values)
        {
            return values.Select(v => (float)v).ToArray();
        }

        public static double[] ToDoubles(this IEnumerable<float> values)
        {
            return values.Select(v => (double)v).ToArray();
        }

        #region single precision

        private const byte _32Bits = sizeof(float);

        public static float[] FastCopy(this float[] source)
        {
            var destination = new float[source.Length];
            Buffer.BlockCopy(source, 0, destination, 0, source.Length * _32Bits);
            return destination;
        }

        public static void FastCopyTo(this float[] source, float[] destination, int size, int sourceOffset = 0, int destinationOffset = 0)
        {
            Buffer.BlockCopy(source, sourceOffset * _32Bits, destination, destinationOffset * _32Bits, size * _32Bits);
        }

        public static float[] FastCopyFragment(this float[] source, int size, int sourceOffset = 0, int destinationOffset = 0)
        {
            var totalSize = size + destinationOffset;
            var destination = new float[totalSize];
            Buffer.BlockCopy(source, sourceOffset * _32Bits, destination, destinationOffset * _32Bits, size * _32Bits);
            return destination;
        }
>
        public static float[] MergeWithArray(this float[] source1, float[] source2)
        {
            var merged = new float[source1.Length + source2.Length];
            Buffer.BlockCopy(source1, 0, merged, 0, source1.Length * _32Bits);
            Buffer.BlockCopy(source2, 0, merged, source1.Length * _32Bits, source2.Length * _32Bits);
            return merged;
        }

        public static float[] RepeatArray(this float[] source, int times)
        {
            var repeated = new float[source.Length * times];

            var offset = 0;
            for (var i = 0; i < times; i++)
            {
                Buffer.BlockCopy(source, 0, repeated, offset * _32Bits, source.Length * _32Bits);
                offset += source.Length;
            }

            return repeated;
        }

        public static float[] PadZeros(this float[] source, int size = 0)
        {
            var zeroPadded = new float[size];
            Buffer.BlockCopy(source, 0, zeroPadded, 0, source.Length * _32Bits);
            return zeroPadded;
        }

        #endregion

        #region double precision

        private const byte _64Bits = sizeof(double);

        public static double[] FastCopy(this double[] source)
        {
            var destination = new double[source.Length];
            Buffer.BlockCopy(source, 0, destination, 0, source.Length * _64Bits);
            return destination;
        }

        public static void FastCopyTo(this double[] source, double[] destination, int size, int sourceOffset = 0, int destinationOffset = 0)
        {
            Buffer.BlockCopy(source, sourceOffset * _64Bits, destination, destinationOffset * _64Bits, size * _64Bits);
        }

        public static double[] FastCopyFragment(this double[] source, int size, int sourceOffset = 0, int destinationOffset = 0)
        {
            var totalSize = size + destinationOffset;
            var destination = new double[totalSize];
            Buffer.BlockCopy(source, sourceOffset * _64Bits, destination, destinationOffset * _64Bits, size * _64Bits);
            return destination;
        }

        public static double[] MergeWithArray(this double[] source1, double[] source2)
        {
            var merged = new double[source1.Length + source2.Length];
            Buffer.BlockCopy(source1, 0, merged, 0, source1.Length * _64Bits);
            Buffer.BlockCopy(source2, 0, merged, source1.Length * _64Bits, source2.Length * _64Bits);
            return merged;
        }

        public static double[] RepeatArray(this double[] source, int times)
        {
            var repeated = new double[source.Length * times];

            var offset = 0;
            for (var i = 0; i < times; i++)
            {
                Buffer.BlockCopy(source, 0, repeated, offset * _64Bits, source.Length * _64Bits);
                offset += source.Length;
            }

            return repeated;
        }

        public static double[] PadZeros(this double[] source, int size = 0)
        {
            var zeroPadded = new double[size];
            Buffer.BlockCopy(source, 0, zeroPadded, 0, source.Length * _64Bits);
            return zeroPadded;
        }

        #endregion
    }

    public static class ArrayHelper
    {
        public static T[] Copy<T>(T[] sourceArray, int length)
        {
            var destinationArray = new T[length];

            Array.Copy(sourceArray, destinationArray, length);

            return destinationArray;
        }

        public static T[] Copy<T>(T[] sourceArray)
        {
            return Copy(sourceArray, sourceArray.Length);
        }

        public static void Fill<T>(T[] sourceArray, T value)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                sourceArray[i] = value;
            }
        }

        public static void Fill<T>(T[] array, int start, int end, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (start < 0 || start > end)
            {
                throw new ArgumentOutOfRangeException("fromIndex");
            }
            if (end >= array.Length)
            {
                throw new ArgumentOutOfRangeException("toIndex");
            }
            for (int i = start; i < end; i++)
            {
                array[i] = value;
            }
        }


        public static string ToString<T>(T[] list)
        {
            return "[" + string.Join(",", list) + "]";
        }
    }

    public class CsvFeatureSerializer
    {
        private double[][] _vectors;

        private List<string> _names;

        private char _delimiter;

        public CsvFeatureSerializer(double[][] featureVectors, char delimiter = ',')
        {
            int sizeVector = featureVectors[0].Length;

            _vectors = featureVectors.ToArray();

            _names = Enumerable.Range(0, sizeVector).Select(i => "coeff" + i).ToList();

            _delimiter = delimiter;
        }

        public async Task SerializeAsync(Stream stream)
        {
            var comma = _delimiter.ToString();

            using (var writer = new StreamWriter(stream))
            {
                if (_names != null)
                {
                    var header = $"{string.Join(comma, _names)}";
                    await writer.WriteLineAsync(header).ConfigureAwait(false);
                }

                foreach (var vector in _vectors)
                {
                    var line = string.Format("{0}", string.Join(comma, vector.Select
                        (
                            f => f.ToString("0.00000", CultureInfo.InvariantCulture)
                        )));

                    await writer.WriteLineAsync(line).ConfigureAwait(false);
                }
            }
        }
    }
}
