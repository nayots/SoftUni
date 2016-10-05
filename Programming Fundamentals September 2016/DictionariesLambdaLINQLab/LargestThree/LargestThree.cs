using System;
using System.Collections.Generic;
using System.Linq;
//04. Largest 3 Numbers
namespace LargestThree
{
    class LargestThree
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            int[] results = nums.OrderByDescending(x => x).Take(3).ToArray();

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
