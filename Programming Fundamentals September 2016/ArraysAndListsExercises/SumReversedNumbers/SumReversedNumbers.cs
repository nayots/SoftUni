using System;
using System.Collections.Generic;
using System.Linq;
//15. Sum Reversed Numbers
namespace SumReversedNumbers
{
    public class SumReversedNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            SumOfRNums(numbers);
        }

        private static void SumOfRNums(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int reversed = 0;
                int temp = numbers[i];
                while (temp > 0)
                {
                    int digit = temp % 10;
                    reversed = (reversed * 10) + digit;
                    temp /= 10;
                }
                sum += reversed;
            }
            Console.WriteLine(sum);
        }
    }
}
