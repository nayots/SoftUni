using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7_BoundedNumbers
{
    class BoundedNumbers
    {
        private static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderBy(x => x).ToArray();

            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(n => n >= bounds[0] && n <= bounds[1]).ToList();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}