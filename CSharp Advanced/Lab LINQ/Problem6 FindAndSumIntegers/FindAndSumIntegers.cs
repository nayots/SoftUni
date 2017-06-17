using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_FindAndSumIntegers
{
    class FindAndSumIntegers
    {
        private static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split()
                .Select(s =>
                {
                    long value;
                    bool parsed = long.TryParse(s, out value);
                    return new { parsed, value };
                })
                .Where(kvp => kvp.parsed == true)
                .Select(n => n.value).ToList();

            if (nums.Count > 0)
            {
                Console.WriteLine(nums.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}