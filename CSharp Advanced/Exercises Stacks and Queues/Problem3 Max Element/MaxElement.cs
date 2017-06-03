using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3_Max_Element
{
    internal class MaxElement
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var numStack = new Stack<int>();

            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int[] inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (inputArgs.Length > 1)
                {
                    numStack.Push(inputArgs[1]);
                    if (inputArgs[1] > max)
                    {
                        max = inputArgs[1];
                    }
                }
                else
                {
                    if (inputArgs[0] == 2)
                    {
                        var element = numStack.Pop();
                        if (element == max && numStack.Count > 0)
                        {
                            max = numStack.Max();
                        }
                        else if (element == max && numStack.Count == 0)
                        {
                            max = int.MinValue;
                        }
                    }
                    else
                    {
                        Console.WriteLine(max);
                    }
                }
            }
        }
    }
}