using System;

#pragma warning disable CA1814
#pragma warning disable S2368

namespace Lab_1_1.RotateMatrix
{
    public static class ArrayExtensions
    {
        public static void Rotate90ClockwiseInt(this int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int len = (int)Math.Sqrt(matrix.Length) - 1;
            int el_1, el_2;

            for (var y = 0; y < (len / 2) + 1; y++)
            {
                for (var x = y; x < len - y; x++)
                {
                    el_1 = matrix[x, len - y];
                    matrix[x, len - y] = matrix[y, x];
                    el_2 = matrix[len - y, len - x];
                    matrix[len - y, len - x] = el_1;
                    el_1 = matrix[len - x, y];
                    matrix[len - x, y] = el_2;
                    matrix[y, x] = el_1;
                }
            }
        }

        public static void Rotate90ClockwiseChar(this char[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            int len = (int)Math.Sqrt(matrix.Length) - 1;
            char el_1, el_2;

            for (var y = 0; y < (len / 2) + 1; y++)
            {
                for (var x = y; x < len - y; x++)
                {
                    el_1 = matrix[x, len - y];
                    matrix[x, len - y] = matrix[y, x];
                    el_2 = matrix[len - y, len - x];
                    matrix[len - y, len - x] = el_1;
                    el_1 = matrix[len - x, y];
                    matrix[len - x, y] = el_2;
                    matrix[y, x] = el_1;
                }
            }
        }
    }
}
