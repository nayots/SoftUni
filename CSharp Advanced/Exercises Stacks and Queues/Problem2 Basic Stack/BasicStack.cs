using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2_Basic_Stack
{
    internal class BasicStack
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputArgs[0];
            int s = inputArgs[1];
            int x = inputArgs[2];

            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numStack = new Stack<int>(nums.Take(n));

            for (int i = 0; i < s; i++)
            {
                numStack.Pop();
            }

            if (numStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numStack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numStack.Min());
                }
            }
        }
    }
}