using System;
//04. Draw a Filled Square
namespace _04.DrawAFilledSquare
{
    class DrawAFilledSquare
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintCube(n);
        }
        static void PrintCube(int num)
        {
            PrintHeaderRow(num);
            PrintMiddleRows(num);
            PrintHeaderRow(num);
        }
        static void PrintHeaderRow(int number)
        {
            Console.WriteLine(new string('-', number * 2));
        }
        static void PrintMiddleRows(int number)
        {
            for (int j = 0; j < number - 2; j++)
            {
                Console.Write("-");
                for (int i = 0; i < number - 1; i++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine("-");
            }
        }
    }
}
