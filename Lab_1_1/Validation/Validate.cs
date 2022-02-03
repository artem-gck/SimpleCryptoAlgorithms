using Lab_1_1.RotateMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab_1_1.Validation
{
    public static class Validate
    {
        private const int SizeOfAlphabet = 26;
        private const char FirstLetterOfAlphabet = 'a';

        public static bool AlphabetValidateInput(string input)
        {
            var alphabets = Enumerable.Range(FirstLetterOfAlphabet, SizeOfAlphabet).Select(num => (char)num).ToList();

            foreach (var let in input)
                if (!alphabets.Contains(let))
                    return false;

            return true;
        }

        public static bool IntValidateKey(string key)
        {
            try
            {
                int.Parse(key);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
