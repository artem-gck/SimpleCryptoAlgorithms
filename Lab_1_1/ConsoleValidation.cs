using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1_1.Validation;

namespace Lab_1_1
{
    public static class ConsoleValidation
    {
        public static int ValidateInt(string inputMessege, int minValue = 0, int maxValue = int.MaxValue)
        {
            Console.Write(inputMessege);
            var input = Console.ReadLine();

            if (Validate.IntValidateKey(input))
            {
                var output = int.Parse(input);

                if (!(output >= minValue && output <= maxValue))
                    return ValidateInt(inputMessege, minValue, maxValue);

                return output;
            }
            else
                return ValidateInt(inputMessege, minValue, maxValue);
        }

        public static string ValidateAlphabet(string inputMessege)
        {
            Console.Write(inputMessege);
            var input = Console.ReadLine();

            return Validate.AlphabetValidateInput(input) ? input : ValidateAlphabet(inputMessege);
        }
    }
}
