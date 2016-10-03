using System;
using System.Collections.Generic;
using System.Linq;
//14. Sort Numbers
namespace SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split(' ')
                .Select(double.Parse)
                .ToList();

            nums.Sort();

            Console.WriteLine(string.Join(" <= ",nums));
        }
    }
}
