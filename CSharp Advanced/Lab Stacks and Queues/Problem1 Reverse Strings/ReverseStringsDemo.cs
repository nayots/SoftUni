using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Reverse_Strings
{
    class ReverseStringsDemo
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stringStack = new Stack<char>();

            foreach (var ch in input)
            {
                stringStack.Push(ch);
            }

            Console.WriteLine(string.Join("",stringStack));
        }
    }
}
