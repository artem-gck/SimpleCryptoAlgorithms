using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1_1.RotateMatrix;
using static System.Math;

namespace Lab_1_1.Algorithms
{
    public static class RotatingLatticeAlgorithm
    {
        public static string Encrypt(string input, int[,] map)
        {
            var sqrtOfInput = Sqrt(input.Length);
            var sizeOfSide = (int)sqrtOfInput + (sqrtOfInput % (int)sqrtOfInput == 0 ? 0 : 1);
            var array = new char[sizeOfSide, sizeOfSide];
            var inputText = new StringBuilder(input);
            var a = (sizeOfSide + (sizeOfSide % 2 == 0 ? 0 : 1)) / 2;
            var b = Pow(a, 2);
            var maxIndex = b - (sizeOfSide % 2 == 0 ? 0 : (sizeOfSide / 2 + 1));


            for (var i = inputText.Length; i < (Pow(sizeOfSide, 2) - sizeOfSide % 2 == 0 ? 0 : 1); i++)
                inputText.Append('#');

            for (var j = 0; j < 4; j++)
            {
                for (var i = 1; i <= maxIndex; i++)
                {
                    var coordinate = GetCoordinate(i, map);
                    array[coordinate.x, coordinate.y] = input[i - 1 + (int)maxIndex * j];
                }

                array.Rotate90ClockwiseChar();
            }

            var output = new StringBuilder(input.Length);

            for (var i = 0; i < sizeOfSide; i++)
                for (var j = 0; j < sizeOfSide; j++)
                {
                    if (array[i, j] != '\0')
                        output.Append(array[i, j]);
                }

            return output.ToString();
        }

        public static string Decrypt(string input, int[,] map)
        {
            var sqrtOfInput = Sqrt(input.Length);
            var sizeOfSide = (int)sqrtOfInput + (sqrtOfInput % (int)sqrtOfInput == 0 ? 0 : 1);
            var array = new char[sizeOfSide, sizeOfSide];
            var output = new StringBuilder(input.Length);
            var a = (sizeOfSide + (sizeOfSide % 2 == 0 ? 0 : 1)) / 2;
            var b = Pow(a, 2);
            var maxIndex = b - (sizeOfSide % 2 == 0 ? 0 : (sizeOfSide / 2 + 1));

            if (sizeOfSide % 2 == 0)
            {
                for (var i = 0; i < sizeOfSide; i++)
                    for (var j = 0; j < sizeOfSide; j++)
                        array[i, j] = input[j + sizeOfSide * i];
            }
            else
            {
                var centre = sizeOfSide / 2;
                var k = 0;

                for (var i = 0; i < sizeOfSide; i++)
                    for (var j = 0; j < sizeOfSide; j++)
                    {
                        if (i == centre && j == centre)
                        {
                            array[i, j] = '\0';
                            k++;
                        }
                        else
                            array[i, j] = input[j + sizeOfSide * i - k];
                    }
            }

            for (var j = 0; j < 4; j++)
            {
                for (var i = 1; i <= maxIndex; i++)
                {
                    var coordinate = GetCoordinate(i, map);
                    output.Append(array[coordinate.x, coordinate.y]);
                }

                array.Rotate90ClockwiseChar();
            }

            return output.ToString().Trim('#');
        }

        public static int[,] GetMap(int input, (int x, int y)[] key)
        {
            var sqrtOfInput = Sqrt(input);
            var sizeOfSide = (int)sqrtOfInput + (sqrtOfInput % (int)sqrtOfInput == 0 ? 0 : 1);
            var index = 1;
            var array = new int[sizeOfSide, sizeOfSide];

            foreach (var item in key)
                array[item.x, item.y] = index++;

            return array;
        }

        private static (int x, int y) GetCoordinate(int number, int[,] map)
        {
            for (var i = 0; i < Sqrt(map.Length); i++)
                for (var j = 0; j < Sqrt(map.Length); j++)
                    if (map[i, j] == number)
                        return (i, j);

            return (-1, -1);
        }
    }
}
