using System;
using System.Linq;

namespace Problem2_DiagonalDifference
{
    class DiagonalDifference
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }

            long sum1 = 0;
            long sum2 = 0;

            for (int j = 0; j < n; j++)
            {
                var num1 = matrix[j][j];
                var num2 = matrix[n - 1 - j][j];

                sum1 += num1;
                sum2 += num2;
            }

            Console.WriteLine(Math.Abs(sum1 - sum2));
        }
    }
}