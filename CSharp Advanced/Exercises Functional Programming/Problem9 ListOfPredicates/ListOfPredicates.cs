using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_ListOfPredicates
{
    class ListOfPredicates
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                return;
            }

            var numbers = new List<int>(Enumerable.Range(1, n));

            var divisors = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToList();

            Predicate<int> isDivisible = (x) =>
            {
                bool divisible = true;
                foreach (var num in divisors)
                {
                    if (x % num != 0)
                    {
                        divisible = false;
                        break;
                    }
                }

                return divisible;
            };

            numbers = numbers.Where(x => isDivisible(x)).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}