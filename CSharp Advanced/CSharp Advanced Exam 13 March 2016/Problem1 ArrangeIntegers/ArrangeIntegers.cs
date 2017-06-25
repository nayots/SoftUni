using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_ArrangeIntegers
{
    class ArrangeIntegers
    {
        private static string[] numbersWords = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        private static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(str =>
                string.Join(string.Empty, str.Select(c => numbersWords[c - '0'])));
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}