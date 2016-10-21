using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//02. Array Manipulator
namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandInfo = command.Split();

                if (commandInfo.Length == 2)
                {
                    string order = commandInfo[0];

                    switch (order)
                    {
                        case "exchange":
                            int index = int.Parse(commandInfo[1]);
                            numbers = DoExchange(numbers, index);
                            break;
                        case "max":
                            DoMax(numbers, commandInfo[1]);
                            break;
                        case "min":
                            DoMin(numbers, commandInfo[1]);
                            break;
                    }
                }
                else
                {
                    string order = commandInfo[0];
                    int count = int.Parse(commandInfo[1]);
                    string type = commandInfo[2];
                    DoFirstLast(numbers, order, count, type);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void DoFirstLast(List<int> numbers, string order, int count, string type)
        {
            List<int> odds = numbers.Where(x => x % 2 != 0).ToList();
            List<int> evens = numbers.Where(x => x % 2 == 0).ToList();
            if (count > numbers.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (order == "first")
                {
                    if (type == "odd")
                    {
                        if (odds.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (count > odds.Count)
                        {
                            Console.WriteLine($"[{string.Join(", ", odds)}]");
                        }
                        else
                        {
                            List<int> temp = odds.Take(count).ToList();
                            Console.WriteLine($"[{string.Join(", ", temp)}]");
                        }
                    }
                    else if (type == "even")
                    {
                        if (evens.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (count > evens.Count)
                        {
                            Console.WriteLine($"[{string.Join(", ", evens)}]");
                        }
                        else
                        {
                            List<int> temp = evens.Take(count).ToList();
                            Console.WriteLine($"[{string.Join(", ", temp)}]");
                        }
                    }
                }
                else if (order == "last")
                {
                    if (type == "odd")
                    {
                        if (odds.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (count > odds.Count)
                        {
                            Console.WriteLine($"[{string.Join(", ", odds)}]");
                        }
                        else
                        {
                            List<int> temp = odds.Skip(odds.Count - count).Take(count).ToList();
                            Console.WriteLine($"[{string.Join(", ", temp)}]");
                        }
                    }
                    else if (type == "even")
                    {
                        if (evens.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (count > evens.Count)
                        {
                            Console.WriteLine($"[{string.Join(", ", evens)}]");
                        }
                        else
                        {
                            List<int> temp = evens.Skip(evens.Count - count).Take(count).ToList();
                            Console.WriteLine($"[{string.Join(", ", temp)}]");
                        }
                    }
                }
            }


        }

        private static void DoMin(List<int> numbers, string type)
        {
            List<int> filtered = new List<int>();
            if (type == "odd")
            {
                filtered = numbers.Where(x => x % 2 != 0).ToList();
            }
            else if (type == "even")
            {
                filtered = numbers.Where(x => x % 2 == 0).ToList();
            }
            if (filtered.Count != 0)
            {
                int minN = filtered.Min();
                Console.WriteLine(numbers.LastIndexOf(minN));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void DoMax(List<int> numbers, string type)
        {
            List<int> filtered = new List<int>();
            if (type == "odd")
            {
                filtered = numbers.Where(x => x % 2 != 0).ToList();
            }
            else if (type == "even")
            {
                filtered = numbers.Where(x => x % 2 == 0).ToList();
            }
            if (filtered.Count != 0)
            {
                int maxN = filtered.Max();
                Console.WriteLine(numbers.LastIndexOf(maxN));
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static List<int> DoExchange(List<int> numbers, int index)
        {
            List<int> exchangeList = new List<int>();
            if (index < 0 || index > numbers.Count - 1)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                exchangeList = numbers.Skip(index + 1).ToList();
                exchangeList.AddRange(numbers.Take(index + 1).ToList());
                numbers = exchangeList;
            }
            return numbers;
        }
    }
}
