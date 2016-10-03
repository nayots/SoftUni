using System;
//02. Reverse Array of Integers
class ReverseArrayOfIntegers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        for (int j = array.Length - 1; j >= 0; j--)
        {
            Console.Write(array[j] + " ");
        }
    }
}
