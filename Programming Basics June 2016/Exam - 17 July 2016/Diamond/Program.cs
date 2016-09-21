using System;
//Diamond
class Diamond
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int row = 0; row < 3 * n + 1; row++)
        {
            for (int col = 0; col < 5 * n; col++)
            {
                if (row == 0 && col >= row + n && col < 5 * n - n)
                {
                    Console.Write("*");
                }
                else if (col == n - row || col == ((6 * n) - 1) - row)//  // lines
                {
                    Console.Write("*");
                }
                else if (col == ((5 * n) - n) + row-1 || col == row - n)//  \\ lines
                {
                    Console.Write("*");
                }
                else if (row == n)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("{0}{1}{0}",new string('.',n * 2 +1),new string('*',n - 2));
    }
}
