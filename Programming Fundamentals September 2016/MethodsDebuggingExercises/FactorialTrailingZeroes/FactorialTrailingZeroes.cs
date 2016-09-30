using System;
using System.Numerics;
//14. Factorial Trailing Zeroes
namespace FactorialTrailingZeroes
{
    class FactorialTrailingZeroes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = FactorialResult(n);
            int zeroes = TrailingZeroesCount(factorial);
            Console.WriteLine(zeroes);
        }

        static int TrailingZeroesCount(BigInteger num)
        {
            int zeroes = 0;
            bool hasZeroes = true;
            while (hasZeroes == true)
            {
                BigInteger digit = num % 10;
                num /= 10;
                if (digit == 0)
                {
                    zeroes++;
                }
                else
                {
                    hasZeroes = false;
                }
            }
            return zeroes;
        }

        static BigInteger FactorialResult(int n)
        {
            BigInteger sum = 0;

            if (n == 1)
            {
                return 1;
            }
            else
            {
                sum = FactorialResult(n - 1) * n;
                return sum;
            }
        }
    }
}
