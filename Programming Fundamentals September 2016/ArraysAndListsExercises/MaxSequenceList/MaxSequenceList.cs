using System;
using System.Collections.Generic;
using System.Linq;
//12. Max Sequence of Equal Elements
namespace MaxSequenceList
{
    class MaxSequenceList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToList();

            FindLongestSequence(numbers);

        }

        private static void FindLongestSequence(List<int> list)
        {
            int start = 0;
            int len = 1;

            int bestPosition = 0;
            int bestLen = 1;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == list[i - 1])
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
                Console.Write($"{list[i]} ");
            }
        }
    }
}
