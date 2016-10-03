using System;
using System.Collections.Generic;
using System.Linq;
//15. Square Numbers
namespace SquareNumbers
{
    class SquareNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> squareNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (Math.Sqrt(number) == (int)Math.Sqrt(number))
                {
                    squareNumbers.Add(number);
                }
            }

            squareNumbers.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine(string.Join(" ",squareNumbers));
        }
    }
}
