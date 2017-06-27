using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_KnightGame
{
    class KnightGame
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];
            int knightsCount = 0;
            List<Horse> horses = new List<Horse>();

            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                matrix[i] = row;
            }

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r][c] == 'K')
                    {
                        CalculateKillCount(matrix, horses, r, c);
                    }
                }
            }

            if (horses.Count > 0)
            {
                horses = horses.OrderByDescending(x => x.KillCount).ToList();

                while (horses.Count > 0)
                {
                    var firstHorse = horses.First();
                    matrix[firstHorse.Row][firstHorse.Col] = '0';
                    knightsCount++;
                    horses.RemoveAt(0);

                    horses = ReevaluateHorses(matrix, horses);
                }
            }

            Console.WriteLine(knightsCount);
        }

        private static List<Horse> ReevaluateHorses(char[][] matrix, List<Horse> horses)
        {
            var results = new List<Horse>();
            for (int i = 0; i < horses.Count; i++)
            {
                int r = horses[i].Row;
                int c = horses[i].Col;

                int row = r;
                int col = c;

                var currentHorse = new Horse(row, col);

                //UP
                //Left
                row = r - 2;
                col = c - 1;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }
                //Right
                col = c + 1;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }

                //DOWN
                //Left
                row = r + 2;
                col = c - 1;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }
                //Right
                col = c + 1;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }

                //LEFT
                //Up
                row = r - 1;
                col = c - 2;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }
                //Down
                row = r + 1;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }
                //RIGHT
                //Up
                row = r - 1;
                col = c + 2;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }
                //Down
                row = r + 1;
                if (IsInMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'K')
                    {
                        currentHorse.KillCount++;
                    }
                }

                if (currentHorse.KillCount > 0)
                {
                    results.Add(currentHorse);
                }
            }
            if (results.Count > 0)
            {
                results = results.OrderByDescending(x => x.KillCount).ToList();
            }
            return results;
        }

        private static void CalculateKillCount(char[][] matrix, List<Horse> horses, int r, int c)
        {
            int row = r;
            int col = c;

            var currentHorse = new Horse(r, c);

            //UP
            //Left
            row = r - 2;
            col = c - 1;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }
            //Right
            col = c + 1;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }

            //DOWN
            //Left
            row = r + 2;
            col = c - 1;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }
            //Right
            col = c + 1;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }

            //LEFT
            //Up
            row = r - 1;
            col = c - 2;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }
            //Down
            row = r + 1;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }
            //RIGHT
            //Up
            row = r - 1;
            col = c + 2;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }
            //Down
            row = r + 1;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row][col] == 'K')
                {
                    currentHorse.KillCount++;
                }
            }

            if (currentHorse.KillCount > 0)
            {
                horses.Add(currentHorse);
            }
        }

        private static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            bool result = ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[0].Length));
            return result;
        }
    }

    class Horse
    {
        public Horse()
        {
        }

        public Horse(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int KillCount { get; set; }
    }
}