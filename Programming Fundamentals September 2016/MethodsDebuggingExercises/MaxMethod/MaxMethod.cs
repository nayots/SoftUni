using System;
//02. Max Method
namespace MaxMethod
{
    class MaxMethod
    {
        static void Main(string[] args)
        {
            int ab = GetMax(int.Parse(Console.ReadLine()),int.Parse(Console.ReadLine()));
            int biggestNumber = GetMax(ab, int.Parse(Console.ReadLine()));

            Console.WriteLine(biggestNumber);
        }

        static int GetMax(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
