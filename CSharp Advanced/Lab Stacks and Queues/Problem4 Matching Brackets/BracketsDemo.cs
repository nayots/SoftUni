using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_Matching_Brackets
{
    class BracketsDemo
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var indexes = new Stack<int>();

            var expressions = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    var startIndex = indexes.Pop();

                    var expr = input.Substring(startIndex, i - startIndex+1);
                    expressions.Add(expr);
                }
            }

            Console.WriteLine(string.Join("\n", expressions));
        }
    }
}
