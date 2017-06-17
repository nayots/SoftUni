using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        private static void Main(string[] args)
        {
            Predicate<int> isEven = (n) => n % 2 == 0;

            var rangeArgs = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var start = rangeArgs[0];
            var end = rangeArgs[1];
            var count = (end - start) + 1;

            var numbers = new List<int>(Enumerable.Range(start, count));

            var oddEven = Console.ReadLine();

            if (oddEven == "odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => isEven(n) == false)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => isEven(n) == true)));
            }
        }
    }
}