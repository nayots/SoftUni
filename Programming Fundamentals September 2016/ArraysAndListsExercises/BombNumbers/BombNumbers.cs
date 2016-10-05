using System;
using System.Collections.Generic;
using System.Linq;
//16. Bomb Numbers
namespace BombNumbers
{
    public class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            BombsAway(sequenceOfNumbers);
        }

        private static void BombsAway(List<int> sequenceOfNumbers)
        {
            List<int> bombInfo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int specialNumber = bombInfo[0];
            int bombPower = bombInfo[1];

            List<int> indexes = new List<int>();

            for (int i = 0; i < sequenceOfNumbers.Count; i++)
            {
                if (sequenceOfNumbers[i] == specialNumber)
                {
                    indexes.Add(i);
                    foreach (int indx in indexes)
                    {
                        int start = 0;
                        int end = 0;
                        if (indx - bombPower > 0)
                        {
                            start = indx - bombPower;
                        }

                        if (indx + bombPower > sequenceOfNumbers.Count - 1)
                        {
                            end = sequenceOfNumbers.Count - 1;
                        }
                        else
                        {
                            end = indx + bombPower;
                        }

                        for (int l = start; l <= end; l++)
                        {
                            sequenceOfNumbers[l] = 0;
                        }
                    }
                }

            }

            int sum = sequenceOfNumbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
