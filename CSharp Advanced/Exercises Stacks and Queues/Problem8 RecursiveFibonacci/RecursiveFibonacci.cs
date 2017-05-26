using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8_RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        private static long[] fibNums;
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            fibNums = new long[n];

            long nthFibo = GetFibo(n);

            Console.WriteLine(nthFibo);
        }

        private static long GetFibo(long n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (fibNums[n - 1] != 0)
            {
                return fibNums[n - 1];
            }
            return fibNums[n - 1] = GetFibo(n - 1) + GetFibo(n - 2);
        }
    }
}
