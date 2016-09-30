using System;
//12. Master Number
namespace MasterNumbers
{
    class MasterNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (ContainsEvenDigitAndCorrectSum(i) == true && IsPalindrome(i) == true)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool ContainsEvenDigitAndCorrectSum(int n)
        {
            bool hasEvenDigit = false;
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                n /= 10;
                if (digit % 2 == 0)
                {
                    hasEvenDigit = true;
                }
                sum += digit;
            }
            if (sum % 7 == 0 && hasEvenDigit == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsPalindrome(int n)
        {
            int inputValue = n;
            string nToString = n.ToString();
            string nStringReversed = "";

            for (int i = nToString.Length - 1; i >= 0; i--)
            {
                nStringReversed += nToString[i];
            }

            if (inputValue == int.Parse(nStringReversed))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
