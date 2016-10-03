using System;
using System.Collections.Generic;
using System.Linq;
//10. Remove Negatives and Reverse
namespace RemoveNegativesAndReverse
{
    class RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> rawData = Console.ReadLine().Split(' ')
                    .Select(int.Parse)
                    .ToList();

            List<int> processedData = new List<int>();

            foreach (int num in rawData)
            {
                if (num >= 0)
                {
                    processedData.Add(num);
                }
            }
            processedData.Reverse();

            if (processedData.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ",processedData));
            }
        }
    }
}
