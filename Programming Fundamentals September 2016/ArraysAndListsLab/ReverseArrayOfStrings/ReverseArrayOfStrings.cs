using System;
using System.Linq;
//06. Reverse Array of Strings
namespace ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ');
            string[] reversed = new string[array.Length];

            Array.Reverse(array);

            Console.WriteLine(string.Join(" ",array));
        }
    }
}
