using System;
using System.Collections.Generic;
using System.Linq;
//01. Largest Common End
namespace LargestCommonEnd
{
    public class LargestCommonEnd
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split(' ');
            string[] arrayTwo = Console.ReadLine().Split(' ');

            int leftCounter = 0;
            int rightCounter = 0;

            for (int i = 0; i <= Math.Min(arrayOne.Length, arrayTwo.Length) - 1; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    leftCounter++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i <= Math.Min(arrayOne.Length, arrayTwo.Length) - 1; i++)
            {
                if (arrayOne[arrayOne.Length -1 - i] == arrayTwo[arrayTwo.Length - 1 - i])
                {
                    rightCounter++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(Math.Max(leftCounter,rightCounter));
        }
    }
}
