using System;
//03. Printing Triangle
namespace _03.PrintingTriangle
{
    class PrintingTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                PrintLine(1, i);
            }
            PrintLine(1, n);
            for (int j = n - 1; j > 0; j--)
            {
                PrintLine(1, j);
            }
        }
        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
