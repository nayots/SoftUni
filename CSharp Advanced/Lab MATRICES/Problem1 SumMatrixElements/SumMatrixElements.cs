using System;
using System.Linq;

namespace Problem1_SumMatrixElements
{
    class SumMatrixElements
    {
        private static void Main(string[] args)
        {
            var matrixArgs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int r = matrixArgs[0];
            int c = matrixArgs[1];
            int[][] matrix = new int[r][];
            var sum = 0;

            for (int i = 0; i < r; i++)
            {
                matrix[i] = new int[c];
                var values = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < c; j++)
                {
                    matrix[i][j] = values[j];
                    sum += values[j];
                }
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(sum);
        }
    }
}