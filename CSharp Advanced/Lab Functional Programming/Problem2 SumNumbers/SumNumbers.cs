using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_SumNumbers
{
    class SumNumbers
    {
        private static void Main(string[] args)
        {
            var res = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            Console.WriteLine(res.Count);
            Console.WriteLine(res.Sum());
        }
    }
}