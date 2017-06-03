using System;
using System.Collections.Generic;

namespace Problem5_Queue_Sequence
{
    internal class QueueSequence
    {
        private static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            int count = 0;

            var numQueue = new Queue<long>();
            numQueue.Enqueue(n);

            while (count < 50)
            {
                var element = numQueue.Dequeue();
                Console.Write($"{element} ");
                numQueue.Enqueue(element + 1);
                numQueue.Enqueue(2 * element + 1);
                numQueue.Enqueue(element + 2);
                count++;
            }
        }
    }
}