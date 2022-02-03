using System.Text;

namespace Lab_1_1.Algorithms
{
    public static class KeyPhraseAlgorithm
    {
        public static string Encrypt(string input, string key)
        {
            var map = GetMap(key);
            var hight = input.Length / key.Length + (input.Length % key.Length == 0 ? 0 : 1);
            var length = key.Length;
            var inputForMatrix = new StringBuilder(input);

            for (var i = input.Length; i < hight * length; i++)
                inputForMatrix.Append('#');

            var output = new StringBuilder(inputForMatrix.ToString());

            for (var i = 0; i < hight; i++)
                for (var j = 0; j < length; j++)
                    output[map[j] - 1 + length * i] = inputForMatrix[j + length * i];

            return output.ToString();
        }

        public static string Decrypt(string input, string key)
        {
            var map = GetMap(key);
            var output = new StringBuilder(input);
            var hight = input.Length / key.Length;
            var length = key.Length;

            for (var i = 0; i < hight; i++)
                for (short j = 1; j <= length; j++)
                {
                    var index = Array.IndexOf(map, j);
                    var letter = input[j + i * length - 1];
                    output[index + length * i] = letter;
                }

            return output.ToString().Trim('#');
        }

        private static short[] GetMap(string key)
        {
            var keyValueArray = new short[key.Length];
            var valueOfKey = (short)1;
            var keyArr = key.ToArray();

            var arr = key.OrderBy(let => let).ToArray();

            for (var i = 0; i < key.Length; i++)
            {
                var index = Array.IndexOf(keyArr, arr[i]);
                keyValueArray[index] = valueOfKey++;
                arr[i] = '\0';
                keyArr[index] = '\0';
            }

            return keyValueArray;
        }
    }
}
