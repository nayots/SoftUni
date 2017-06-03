using System;
using System.Linq;

namespace Problem3_SquaresInMatrix
{
    class SquaresInMatrix
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var r = inputArgs[0];
            var c = inputArgs[1];

            string[][] matrix = new string[r][];

            for (int i = 0; i < r; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            int squares = 0;

            for (int row = 0; row < r - 1; row++)
            {
                for (int col = 0; col < c - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] && matrix[row][col] == matrix[row + 1][col] && matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        squares++;
                    }
                }
            }

            Console.WriteLine(squares);
        }
    }
}