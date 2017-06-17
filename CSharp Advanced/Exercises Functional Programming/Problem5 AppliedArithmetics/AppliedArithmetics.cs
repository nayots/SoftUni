using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_AppliedArithmetics
{
    class AppliedArithmetics
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = (n) => n.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> multiply = (n) => n.Select(x => x * 2).ToList();
            Func<List<int>, List<int>> subtract = (n) => n.Select(x => x - 1).ToList();
            Action<List<int>> print = (n) => Console.WriteLine(string.Join(" ", n));

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;

                    case "multiply":
                        numbers = multiply(numbers);
                        break;

                    case "subtract":
                        numbers = subtract(numbers);
                        break;

                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}