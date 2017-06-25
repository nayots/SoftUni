using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_JediGalaxy
{
    class JediGalaxy
    {
        private static long sum;

        private static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var n = dimensions[0];
            var m = dimensions[1];
            var counter = 0;
            int[][] matrix = new int[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                var row = new int[m];
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = counter;
                    counter++;
                }
                matrix[i] = row;
            }

            var input = Console.ReadLine();

            while (input != "Let the Force be with you")
            {
                var jediArgs = input.Split().Select(int.Parse).ToArray();
                var evilArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var jediRow = jediArgs[0];
                var jediCol = jediArgs[1];
                var evilRow = evilArgs[0];
                var evilCol = evilArgs[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (IsMatrix(evilRow, evilCol, matrix))
                    {
                        matrix[evilRow][evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                while (jediRow >= 0 && jediCol < matrix[0].Length)
                {
                    if (IsMatrix(jediRow, jediCol, matrix))
                    {
                        sum += matrix[jediRow][jediCol];
                    }
                    jediRow--;
                    jediCol++;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }

        private static bool IsMatrix(int row, int col, int[][] matrix)
        {
            bool result = row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length;

            return result;
        }
    }
}