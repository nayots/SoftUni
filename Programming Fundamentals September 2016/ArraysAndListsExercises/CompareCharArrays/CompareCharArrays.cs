using System;
using System.Collections.Generic;
using System.Linq;
//05. Compare Char Arrays
namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            char[] arrayOne = Console.ReadLine().Split(' ')
                .Select(char.Parse)
                .ToArray();

            char[] arrayTwo = Console.ReadLine().Split(' ')
                .Select(char.Parse)
                .ToArray();

            bool oneIsFirst = false;
            bool twoIsFirst = false;

            for (int i = 0; i < Math.Min(arrayOne.Length, arrayTwo.Length); i++)
            {
                if (arrayOne[i] < arrayTwo[i])
                {
                    oneIsFirst = true;
                    break;
                }
                else if (arrayOne[i] > arrayTwo[i])
                {
                    twoIsFirst = true;
                    break;
                }
            }

            if (oneIsFirst)
            {
                Console.WriteLine(string.Join("", arrayOne));
                Console.WriteLine(string.Join("", arrayTwo));
            }
            else if (twoIsFirst)
            {
                Console.WriteLine(string.Join("", arrayTwo));
                Console.WriteLine(string.Join("", arrayOne));
            }
            else
            {
                if (arrayOne.Length > arrayTwo.Length)
                {
                    Console.WriteLine(string.Join("", arrayTwo));
                    Console.WriteLine(string.Join("", arrayOne));
                }
                else
                {
                    Console.WriteLine(string.Join("", arrayOne));
                    Console.WriteLine(string.Join("", arrayTwo));
                }
            }
        }
    }
}
