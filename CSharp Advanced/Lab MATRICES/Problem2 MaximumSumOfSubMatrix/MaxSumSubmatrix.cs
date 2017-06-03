using System;
using System.Linq;

namespace Problem2_MaximumSumOfSubMatrix
{
    class MaxSumSubmatrix
    {
        private static void Main(string[] args)
        {
            var matrixArgs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int r = matrixArgs[0];
            int c = matrixArgs[1];
            int[][] matrix = new int[r][];
            var maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < r; i++)
            {
                matrix[i] = new int[c];
                var values = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < c; j++)
                {
                    matrix[i][j] = values[j];
                }
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var currentSUm = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];
                    if (currentSUm > maxSum)
                    {
                        maxSum = currentSUm;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex][colIndex]} {matrix[rowIndex][colIndex + 1]}\n{matrix[rowIndex + 1][colIndex]} {matrix[rowIndex + 1][colIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}