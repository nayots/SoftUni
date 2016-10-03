using System;
//05. Rounding Numbers
namespace RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            string[] numbersArray = Console.ReadLine().Split(' ');
            double[] parsedNumbers = new double[numbersArray.Length];

            for (int i = 0; i < numbersArray.Length; i++)
            {
                parsedNumbers[i] = double.Parse(numbersArray[i]);
            }

            for (int j = 0; j < parsedNumbers.Length; j++)
            {
                Console.Write($"{parsedNumbers[j]} => ");
                parsedNumbers[j] = Math.Round(parsedNumbers[j], MidpointRounding.AwayFromZero);
                Console.WriteLine(parsedNumbers[j]);
            }
        }
    }
}
