using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem12_MatrixRotation
{
    class MatrixRotation
    {
        private static void Main(string[] args)
        {
            var match = Regex.Match(Console.ReadLine(), @".*\((\d+)\).*");

            int degrees = int.Parse(match.Groups[1].Value);

            int rotations = (degrees % 360) / 90;

            List<List<char>> matrix = new List<List<char>>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                matrix.Add(input.ToCharArray().ToList());

                input = Console.ReadLine();
            }

            int maxLength = matrix.Max(x => x.Count);

            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count < maxLength)
                {
                    while (matrix[i].Count < maxLength)
                    {
                        matrix[i].Add(' ');
                    }
                }
            }
            if (rotations > 0)
            {
                for (int i = 0; i < rotations; i++)
                {
                    RotateMatrix(matrix);
                }
            }
            PrintMatrix(matrix);
        }

        private static void RotateMatrix(List<List<char>> matrix)
        {
            List<List<char>> result = new List<List<char>>();

            for (int c = 0; c < matrix.Max(x => x.Count); c++)
            {
                var chars = new List<char>();
                for (int r = matrix.Count - 1; r >= 0; r--)
                {
                    chars.Add(matrix[r][c]);
                }
                result.Add(chars);
            }
            matrix.Clear();

            matrix.AddRange(result);
        }

        private static void PrintMatrix(List<List<char>> matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
    }
}