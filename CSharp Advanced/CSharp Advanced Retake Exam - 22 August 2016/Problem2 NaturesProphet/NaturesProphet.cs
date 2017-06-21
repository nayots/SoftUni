using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_NaturesProphet
{
    class NaturesProphet
    {
        private static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] garden = new int[dimensions[0]][];
            for (int i = 0; i < garden.Length; i++)
            {
                garden[i] = new int[dimensions[1]];
            }

            var input = Console.ReadLine();
            var seeds = new List<Seed>();
            while (input != "Bloom Bloom Plow")
            {
                var seed = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                seeds.Add(new Seed(seed[0], seed[1]));
                input = Console.ReadLine();
            }

            foreach (var seed in seeds.OrderBy(x => x.Row).ThenBy(x => x.Col))
            {
                var currentPos = garden[seed.Row][seed.Col];
                for (int c = 0; c < garden[seed.Row].Length; c++)
                {
                    garden[seed.Row][c] += 1;
                }

                for (int r = 0; r < garden.Length; r++)
                {
                    garden[r][seed.Col] += 1;
                }

                garden[seed.Row][seed.Col] = currentPos + 1;
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }

    class Seed
    {
        public Seed(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}