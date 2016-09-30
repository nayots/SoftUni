using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }

        static long Fib(long n)
        {
            long oneStepBehind = 1;
            long currrentNumber = 0;
            for (int i = 0; i <= n; i++)
            {
                long tempLong = currrentNumber;
                currrentNumber += oneStepBehind;
                oneStepBehind = tempLong;
            }
            return currrentNumber;
        }
    }
}
