using System;
using System.Collections.Generic;

namespace Problem9_Stack_Fibonacci
{
    internal class StackFibonacci
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fiboStack = new Stack<long>();
            fiboStack.Push(0L);
            fiboStack.Push(1L);

            while (fiboStack.Count <= n)
            {
                var ele = fiboStack.Pop();
                var newEle = ele + fiboStack.Peek();
                fiboStack.Push(ele);
                fiboStack.Push(newEle);
            }

            Console.WriteLine(fiboStack.Peek());
        }
    }
}