using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem2_Simple_Calculator
{
    class SimpleCalculatorDemo
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var values = input.Split(' ');
            var stack = new Stack<string>(values.Reverse());
            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                String op = stack.Pop();
                int second = int.Parse(stack.Pop());
                switch (op)
                {
                    case "+":
                        stack.Push((first + second).ToString()); break;
                    case "-":
                        stack.Push((first - second).ToString()); break;
                }

            }
            Console.WriteLine(stack.Pop());
        }
    }
}
