using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7_BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            bool isBalanced = true;

            Stack<char> chars = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == ')')
                {
                    if (chars.Count < 1)
                    {
                        isBalanced = false;
                        break;
                    }
                    var prevEle = chars.Pop();
                    if (prevEle != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (input[i] == '}')
                {
                    if (chars.Count < 1)
                    {
                        isBalanced = false;
                        break;
                    }
                    var prevEle = chars.Pop();
                    if (prevEle != '{')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (input[i] == ']')
                {
                    if (chars.Count < 1)
                    {
                        isBalanced = false;
                        break;
                    }
                    var prevEle = chars.Pop();
                    if (prevEle != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else
                {
                    chars.Push(input[i]);
                }

            }
            if (input.Length < 2 || (!input.Contains(")") && !input.Contains("}") && !input.Contains("]")))
            {
                isBalanced = false;
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
