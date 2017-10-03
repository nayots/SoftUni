using System;
using System.Linq;
using System.Threading;

namespace Problem1_EvenNumbersThread
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var start = tokens[0];
            var end = tokens[1];

            Thread evens = new Thread(() => PrintEvenNumbs(start, end));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work");
        }

        public static void PrintEvenNumbs(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}