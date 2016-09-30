using System;
using System.Collections.Generic;
//07. Primes in Given Range
namespace PrimesInGivenRange
{
    class PrimesInGivenRange
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            List<int> listOfPrimes = FindPrimesInRange(startNumber, endNumber);
            for (int i = 0; i < listOfPrimes.Count; i++)
            {
                Console.Write(listOfPrimes[i]);
                if (i != listOfPrimes.Count - 1)
                {
                    Console.Write(", ");
                }
            }

        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primesList = new List<int>();
            for (int i = startNum; i <= endNum; i++)
            {
                bool primeCheck = true;
                if (i == 0 || i == 1)
                {
                    primeCheck = false;
                }
                else
                {
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            primeCheck = false;
                        }
                    }
                }
                if (primeCheck)
                {
                    primesList.Add(i);
                }
            }
            return primesList;
        }
    }
}