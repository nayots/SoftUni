using System;
//Problem 8: SquareOfStars
class SquareOfStars
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (row == 0 || row == n - 1)
                {
                    Console.Write('*');
                }
                else if (col == 0 || col == n - 1)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
