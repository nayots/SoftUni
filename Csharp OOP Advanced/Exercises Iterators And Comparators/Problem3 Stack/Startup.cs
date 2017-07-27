using Problem3_Stack.Models.Genrics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3_Stack
{
    class Startup
    {
        private static void Main(string[] args)
        {
            string input = string.Empty;

            CustomStack<int> myStack = new CustomStack<int>();

            while ((input = Console.ReadLine()) != "END")
            {
                List<string> tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = tokens[0];
                int[] numbers = tokens.Skip(1).Select(int.Parse).ToArray();
                try
                {
                    switch (command)
                    {
                        case "Push":
                            foreach (var num in numbers)
                            {
                                myStack.Push(num);
                            }
                            break;

                        case "Pop":
                            myStack.Pop();
                            break;

                        default:
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (myStack.Any())
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, myStack));
                }
            }
        }
    }
}