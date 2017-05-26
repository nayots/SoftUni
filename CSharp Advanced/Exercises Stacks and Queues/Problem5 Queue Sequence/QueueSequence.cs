using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_Queue_Sequence
{
    class QueueSequence
    {
        static void Main(string[] args)
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
                numQueue.Enqueue(2*element + 1);
                numQueue.Enqueue(element + 2);
                count++;
            }
        }
    }
}
