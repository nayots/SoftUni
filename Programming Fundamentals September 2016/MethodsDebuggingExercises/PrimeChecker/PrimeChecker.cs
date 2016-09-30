using System;
//06. Prime Checker
namespace PrimeChecker
{
    class PrimeChecker
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(isPrime(number));
        }

        static bool isPrime(long n)
        {
            bool primeCheck = true;
            if (n == 0 || n == 1)
            {
                primeCheck = false;
                return primeCheck;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        primeCheck = false;
                    }
                }
                return primeCheck;
            }

        }
    }
}
