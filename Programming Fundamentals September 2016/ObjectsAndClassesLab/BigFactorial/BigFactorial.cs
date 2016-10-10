using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
//03. Big Factorial
namespace BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
