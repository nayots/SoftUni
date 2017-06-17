using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8_CustomComparator
{
    class CustomComparator
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var evenNumbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            var oddNumber = numbers.Where(x => x % 2 != 0).OrderBy(x => x).ToList();

            evenNumbers.AddRange(oddNumber);
            Console.WriteLine(string.Join(" ", evenNumbers));
        }
    }
}