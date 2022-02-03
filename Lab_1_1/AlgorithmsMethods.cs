using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1_1.Algorithms;
using static System.Math;

namespace Lab_1_1
{
    public static class AlgorithmsMethods
    {
        private const string CryptChoose = "1. Encrypt\n2. Decrypt";
        private const string Choice = "Input your choise: ";
        private const string Input = "Input string: ";
        private const string Key = "Input key: ";

        public static string Railway()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 2);

            Console.WriteLine();

            Console.Write(Input);
            var input = Console.ReadLine();

            var key = ConsoleValidation.ValidateInt(Key);

            Console.WriteLine();

            return choose switch
            {
                1 => RailwayAlgorithm.Encrypt(input, key),
                2 => RailwayAlgorithm.Decrypt(input, key),
            };
        }

        public static string KeyPhrase()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 2);

            Console.WriteLine();

            Console.Write(Input);
            var input = Console.ReadLine();

            Console.Write(Key);
            var key = Console.ReadLine();

            Console.WriteLine();

            return choose switch
            {
                1 => KeyPhraseAlgorithm.Encrypt(input, key),
                2 => KeyPhraseAlgorithm.Decrypt(input, key),
            };
        }

        public static string RotatingLattice()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 2);

            Console.WriteLine();

            Console.Write(Input);
            var input = Console.ReadLine();

            Console.WriteLine();

            var sqrtOfInput = Sqrt(input.Length);
            var sizeOfSide = (int)sqrtOfInput + (sqrtOfInput % (int)sqrtOfInput == 0 ? 0 : 1);
            var a = (sizeOfSide + (sizeOfSide % 2 == 0 ? 0 : 1)) / 2;
            var b = Pow(a, 2);
            var index = (int)(b - (sizeOfSide % 2 == 0 ? 0 : (sizeOfSide / 2 + 1)));
            var maxIndex = index % 2 == 0 ? index : (index - 1);
            var coordinates = new (int x, int y)[maxIndex];

            Console.WriteLine($"Side of matrix is {sizeOfSide}\nPlease input {maxIndex} coordinates:");

            for (var i = 0; i < maxIndex; i++)
            {
                var x = ConsoleValidation.ValidateInt($"{i + 1} x: ", 1, sizeOfSide);
                var y = ConsoleValidation.ValidateInt($"{i + 1} y: ", 1, sizeOfSide);

                coordinates[i] = (x - 1, y - 1);
            }

            var map = RotatingLatticeAlgorithm.GetMap(input.Length, coordinates);

            return choose switch
            {
                1 => RotatingLatticeAlgorithm.Encrypt(input, map),
                2 => RotatingLatticeAlgorithm.Decrypt(input, map),
            };
        }

        public static string Cesar()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 2);

            Console.WriteLine();

            var input = ConsoleValidation.ValidateAlphabet(Input);
            var key = ConsoleValidation.ValidateInt(Key);

            Console.WriteLine();

            return choose switch
            {
                1 => CesarAlgorithm.Encrypt(input, key),
                2 => CesarAlgorithm.Decrypt(input, key),
            };
        }

        public static string NewCesar()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 2);

            Console.WriteLine();

            var input = ConsoleValidation.ValidateAlphabet(Input);
            var key = ConsoleValidation.ValidateInt(Key);

            Console.WriteLine();

            return choose switch
            {
                1 => CesarNewAlgorithm.Encrypt(input, key),
                2 => CesarNewAlgorithm.Decrypt(input, key),
            };
        }
    }
}
