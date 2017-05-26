using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_ReverseNumbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            Stack<long> nums = new Stack<long>(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray());

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
