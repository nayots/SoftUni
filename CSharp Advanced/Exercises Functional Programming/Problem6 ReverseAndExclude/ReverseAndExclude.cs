using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_ReverseAndExclude
{
    class ReverseAndExclude
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = (nn) => nn % n == 0;

            Func<List<int>, int, List<int>> reverseAndExclude = (nums, x) =>
           {
               nums.Reverse();
               nums = nums.Where(y => !isDivisible(y)).ToList();
               return nums;
           };

            Console.WriteLine(string.Join(" ", reverseAndExclude(numbers, n)));
        }
    }
}