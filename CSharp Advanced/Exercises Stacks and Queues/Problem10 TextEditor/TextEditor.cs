using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem10_TextEditor
{
    internal class TextEditor
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var text = new Stack<string>();
            text.Push(string.Empty);

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var t = string.Empty;

                switch (commandArgs[0])
                {
                    case "1":
                        t = text.Peek();
                        text.Push(t + commandArgs[1]);
                        break;

                    case "2":
                        t = text.Peek();
                        int count = int.Parse(commandArgs[1]);
                        text.Push(t.Substring(0, t.Length - count));
                        break;

                    case "3":
                        int index = int.Parse(commandArgs[1]);
                        t = text.Peek();
                        Console.WriteLine(t[index - 1]);
                        break;

                    case "4":
                        text.Pop();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}