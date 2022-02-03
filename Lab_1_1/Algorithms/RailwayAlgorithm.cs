using System.Text;

namespace Lab_1_1.Algorithms
{
    public static class RailwayAlgorithm
    {
        public static string Encrypt(string input, int key)
        {
            var map = GetMap(input.Length, key);
            var output = new StringBuilder(input.Length);

            foreach(var item in map)
            {
                for (var i = 0; i < item.Count; i++)
                {
                    output.Append(input[item[i]]);
                }
            }

            return output.ToString();
        }

        public static string Decrypt(string input, int key)
        {
            var map = GetMap(input.Length, key);
            var output = new StringBuilder(input);
            var index = 0;

            foreach (var item in map)
            {
                for (var i = 0; i < item.Count; i++)
                {
                    output[item[i]] = input[index++];
                }
            }

            return output.ToString();
        }

        private static List<int>[] GetMap(int input, int key)
        {
            var period = 2 * (key - 1);
            var array = new List<int>[key];

            for (var i = 0; i < key; i++)
                array[i] = new List<int>();

            for (var i = 0; i < input; i++)
            {
                var ost = i % period;
                var row = ost < (key - 1) ? ost : period - ost;
                array[row].Add(i);
            }

            return array;
        }
    }
}