using System;
using System.Collections.Generic;
using System.Linq;
//07. Max Sequence of Increasing Elements
namespace MaxSeqIncrEle
{
    public class MaxSeqIncrEle
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            FindLongestSequence(numbers);

        }

        private static void FindLongestSequence(int[] array)
        {
            int start = 0;
            int len = 1;

            int bestPosition = 0;
            int bestLen = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[i - 1])
                {
                    len++;
                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestPosition = start;
                    }
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestPosition = start;
                        bestLen = len;
                    }
                    start = i;
                    len = 1;
                }
            }

            for (int i = bestPosition; i < bestPosition + bestLen; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
