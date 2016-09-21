using System;
//Square Frame
class SquareFrame
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            if (i == 0 || i == n - 1)
            {
                Console.Write("+");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine(" +");
            }
            else
            {
                Console.Write("|");
                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write(" -");
                }
                Console.WriteLine(" |");
            }
        }
    }
}
