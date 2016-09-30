using System;
//03. English Name of Last Digit
namespace EnglishNameOfLastDigit
{
    class EnglishNameOfLastDigit
    {
        static void Main(string[] args)
        {
            long n = Math.Abs(long.Parse(Console.ReadLine()));
            Console.WriteLine(GetLastDigitName(n));
        }

        static string GetLastDigitName(long inputNumber)
        {
            long lastDigit = inputNumber % 10;
            string digitname = "";
            switch (lastDigit)
            {
                case 0:
                    digitname = "zero";
                    break;
                case 1:
                    digitname = "one";
                    break;
                case 2:
                    digitname = "two";
                    break;
                case 3:
                    digitname = "three";
                    break;
                case 4:
                    digitname = "four";
                    break;
                case 5:
                    digitname = "five";
                    break;
                case 6:
                    digitname = "six";
                    break;
                case 7:
                    digitname = "seven";
                    break;
                case 8:
                    digitname = "eight";
                    break;
                case 9:
                    digitname = "nine";
                    break;
            }
            return digitname;
        }
    }
}
