using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1_ReverseNumbers
{
    internal class ReverseNumbers
    {
        private static void Main(string[] args)
        {
            Stack<long> nums = new Stack<long>(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray());

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}