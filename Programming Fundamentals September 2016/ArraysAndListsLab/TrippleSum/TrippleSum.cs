using System;
using System.Linq;
//04. Tripple Sum
namespace TrippleSum
{
    class TrippleSum
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');

            int[] array = new int[numbers.Length];
            bool hasMatch = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }

            for (int j = 0; j < array.Length; j++)
            {
                for (int l = j + 1; l < array.Length; l++)
                {
                    int sum = array[j] + array[l];

                    if (array.Contains(sum))
                    {

                        Console.WriteLine($"{array[j]} + {array[l]} == {sum}");
                        hasMatch = true;
                    }
                }
            }
            if (!hasMatch)
            {
                Console.WriteLine("No");
            }
        }
    }
}
