using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7_LegoBlocks
{
    class LegoBlocks
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jArray1 = new int[n][];
            int[][] jArray2 = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jArray1[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                jArray2[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
            }

            int comparator = jArray1[0].Length + jArray2[0].Length;

            bool fit = true;

            for (int i = 0; i < n - 1; i++)
            {
                if (jArray1[i].Length + jArray2[i].Length != jArray1[i + 1].Length + jArray2[i + 1].Length)
                {
                    fit = false;
                    break;
                }
            }

            if (fit)
            {
                PrintArrays(jArray1, jArray2);
            }
            else
            {
                var num = 0;
                for (int i = 0; i < n; i++)
                {
                    num += jArray1[i].Length + jArray2[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {num}");
            }
        }

        private static void PrintArrays(int[][] jArray1, int[][] jArray2)
        {
            for (int i = 0; i < jArray1.Length; i++)
            {
                List<int> items = new List<int>();
                items.AddRange(jArray1[i]);
                items.AddRange(jArray2[i]);
                Console.WriteLine($"[{string.Join(", ", items)}]");
            }
        }
    }
}