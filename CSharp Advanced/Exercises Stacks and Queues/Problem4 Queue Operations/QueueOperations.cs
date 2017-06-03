using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4_Queue_Operations
{
    internal class QueueOperations
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputArgs[0];
            int s = inputArgs[1];
            int x = inputArgs[2];

            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numQueue = new Queue<int>(nums.Take(n));

            for (int i = 0; i < s; i++)
            {
                numQueue.Dequeue();
            }

            if (numQueue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numQueue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numQueue.Min());
                }
            }
        }
    }
}