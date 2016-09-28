using System;
//08. Multiply Evens by Odds
namespace _08.MultiplyEvensByOdds
{
    class MultiplyEvensByOdds
    {
        static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine($"{ResultOfMultiplication(n)}");

        }
        static int SumOfEvenDigits(int n)
        {
            int Sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                {
                    Sum += lastDigit;
                }
                n /= 10;
            }
            return Sum;
        }
        static int SumOfOddDigits(int n)
        {
            int Sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                {
                    Sum += lastDigit;
                }
                n /= 10;
            }
            return Sum;
        }
        static int ResultOfMultiplication(int n)
        {
            int sumOfEvens = SumOfEvenDigits(n);
            int sumOfOdds = SumOfOddDigits(n);
            int result = sumOfEvens * sumOfOdds;
            return result;
        }
    }
}
