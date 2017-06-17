using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_SortEvenNumbers
{
    class SortEvenNumbers
    {
        private static void Main(string[] args)
        {
            var res = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", res.OrderBy(x => x)));
        }
    }
}