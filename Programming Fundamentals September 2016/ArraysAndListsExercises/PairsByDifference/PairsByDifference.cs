using System;
using System.Collections.Generic;
using System.Linq;
//10. Pairs by Difference
namespace PairsByDifference
{
    public class PairsByDifference
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            FindPair(numbers);
        }

        private static void FindPair(int[] numbers)
        {
            int difference = int.Parse(Console.ReadLine());
            int pairs = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        if (Math.Abs(numbers[i]-numbers[j]) == difference)
                        {
                            pairs++;
                        }
                    }
                }
            }
            Console.WriteLine(pairs);
        }
    }
}
