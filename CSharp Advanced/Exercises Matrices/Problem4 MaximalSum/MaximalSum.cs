using System;
using System.Linq;

namespace Problem4_MaximalSum
{
    class MaximalSum
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var r = inputArgs[0];
            var c = inputArgs[1];

            long[][] matrix = new long[r][];

            for (int i = 0; i < r; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }

            var maxSumSquareRowIndex = 0;
            var maxSumSquareColIndex = 0;
            long maxSum = 0;
            long currentSum = 0;

            for (int row = 0; row < r - 2; row++)
            {
                for (int col = 0; col < c - 2; col++)
                {
                    currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumSquareRowIndex = row;
                        maxSumSquareColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxSumSquareRowIndex][maxSumSquareColIndex]} {matrix[maxSumSquareRowIndex][maxSumSquareColIndex + 1]} {matrix[maxSumSquareRowIndex][maxSumSquareColIndex + 2]}");
            Console.WriteLine($"{matrix[maxSumSquareRowIndex + 1][maxSumSquareColIndex]} {matrix[maxSumSquareRowIndex + 1][maxSumSquareColIndex + 1]} {matrix[maxSumSquareRowIndex + 1][maxSumSquareColIndex + 2]}");
            Console.WriteLine($"{matrix[maxSumSquareRowIndex + 2][maxSumSquareColIndex]} {matrix[maxSumSquareRowIndex + 2][maxSumSquareColIndex + 1]} {matrix[maxSumSquareRowIndex + 2][maxSumSquareColIndex + 2]}");
        }
    }
}