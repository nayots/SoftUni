using System;
using System.Collections.Generic;
using System.Linq;
//02. Rotate and Sum
namespace RotateAndSum
{
    public class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = int.Parse(Console.ReadLine());

            int[] rotated = new int[numbers.Length];

            for (int i = 0; i < k; i++)
            {
                int temp = numbers[numbers.Length - 1];
                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    numbers[j] = numbers[j - 1];

                }
                numbers[0] = temp;

                for (int l = 0; l < numbers.Length; l++)
                {
                    rotated[l] += numbers[l];
                }
            }

            Console.WriteLine(string.Join(" ", rotated));
        }
    }
}
