using System;
using System.Collections.Generic;
using System.Linq;
//01. Count Real Numbers
namespace CountRealNumbers
{
    public class CountRealNumbers
    {
        static void Main(string[] args)
        {
            double[] realNums = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            CountNumbers(realNums);
        }

        private static void CountNumbers(double[] realNums)
        {

            SortedDictionary<double, int> sortedNums = new SortedDictionary<double, int>();

            foreach (double num in realNums)
            {
                if (sortedNums.ContainsKey(num))
                {
                    sortedNums[num] += 1;
                }
                else
                {
                    sortedNums.Add(num, 1);
                }
            }

            foreach (KeyValuePair<double,int> entry in sortedNums)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
