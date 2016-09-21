using System;
//Rectangle of N x N Stars
class SquareNXNStars
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("*");
            for (int j = 0; j < n - 1; j++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
        }
    }
}
