using System;
using System.Linq;

namespace Problem3_DependencyInversion
{
    class Startup
    {
        private static void Main(string[] args)
        {
            PrimitiveCalculator calc = new PrimitiveCalculator();

            string commandArgs = string.Empty;

            while ((commandArgs = Console.ReadLine()) != "End")
            {
                if (commandArgs.StartsWith("mode"))
                {
                    char @operator = commandArgs.TrimEnd().ToCharArray().Last();
                    calc.ChangeStrategy(@operator);
                }
                else
                {
                    int[] numbers = commandArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    Console.WriteLine(calc.PerformCalculation(numbers[0], numbers[1]));
                }
            }
        }
    }
}