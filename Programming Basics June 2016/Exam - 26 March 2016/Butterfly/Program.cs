using System;
//Butterfly
class Butterfly
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int width = 2 * n - 1;
        int height = 2 * (n - 2) + 1;

        for (int i = 0; i < height; i++)
        {
            if (i == height / 2)
            {
                Console.WriteLine("{0}@{0}", new string(' ', n - 1));
            }
            else
            {
                if (i % 2 == 0)
                {
                    if (i < height / 2)
                    {
                        Console.WriteLine("{0}\\ /{0}", new string('*', n - 2));
                    }
                    else if (i > height / 2)
                    {
                        Console.WriteLine("{0}/ \\{0}", new string('*', n - 2));
                    }
                }
                else if (i % 2 != 0)
                {
                    if (i < height / 2)
                    {
                        Console.WriteLine("{0}\\ /{0}", new string('-', n - 2));
                    }
                    else if (i > height / 2)
                    {
                        Console.WriteLine("{0}/ \\{0}", new string('-', n - 2));
                    }
                }
            }
        }
    }
}
