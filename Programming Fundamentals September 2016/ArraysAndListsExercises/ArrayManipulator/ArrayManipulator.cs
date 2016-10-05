using System;
using System.Collections.Generic;
using System.Linq;
//14. Array Manipulator
namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            bool canContinue = true;

            while (canContinue)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                switch (commands[0])
                {
                    case "add":
                        AddElements(numbers, commands);
                        break;
                    case "addMany":
                        int indx = int.Parse(commands[1]);
                        numbers.InsertRange(indx, commands.Skip(2).Select(int.Parse));
                        break;
                    case "contains":
                        ContainsElement(numbers, commands);
                        break;
                    case "remove":
                        numbers.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "shift":
                        ShiftElements(numbers, commands);
                        break;
                    case "sumPairs":
                        SumPairs(numbers);
                        break;
                    case "print":
                        Console.WriteLine("[{0}]",string.Join(", ", numbers));
                        canContinue = false;
                        break;
                }
            }
        }

        private static void SumPairs(List<int> numbers)
        {

            if (numbers.Count % 2 != 0)
            {
                numbers.Insert(numbers.Count - 1, 0);
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                numbers[i] = numbers[i] + numbers[i + 1];
                numbers.RemoveAt(i + 1);
            }

        }

        private static void ShiftElements(List<int> numbers, List<string> commands)
        {
            int positions = int.Parse(commands[1]);

            for (int i = 0; i < positions; i++)
            {
                int last = numbers[0];

                numbers.RemoveAt(0);
                numbers.Add(last);
            }
        }


        private static void ContainsElement(List<int> numbers, List<string> commands)
        {
            int element = int.Parse(commands[1]);

            if (numbers.Contains(element))
            {
                Console.WriteLine(numbers.IndexOf(element));
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        private static void AddElements(List<int> numbers, List<string> commands)
        {
            int index = int.Parse(commands[1]);
            int element = int.Parse(commands[2]);

            numbers.Insert(index, element);
        }
    }
}
