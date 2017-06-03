using System;
using System.Linq;

namespace Problem1_PalindromesMatrix
{
    class PalindromesMatrix
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = inputArgs[0];
            int cols = inputArgs[1];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[][] matrix = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new string[cols];
                matrix[i][0] = $"{alphabet[i]}{alphabet[i]}{alphabet[i]}";
                for (int j = 1; j < cols; j++)
                {
                    int currentChar = matrix[i][j - 1][1] + 1;

                    matrix[i][j] = $"{alphabet[i]}{(char)currentChar}{alphabet[i]}";
                }
            }

            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}