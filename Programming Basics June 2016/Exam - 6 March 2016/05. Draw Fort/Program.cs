using System;
class DrawFort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (i == 0)//Top
            {
                Console.Write("/{0}\\", new string('^', n / 2));
                if (n > 4)
                {
                    Console.Write("{0}", new string('_', 2 * n - (2 * (n / 2) + 4)));
                }
                Console.WriteLine("/{0}\\", new string('^', n / 2));
            }
            else if (i == n - 1)//Bottom
            {
                Console.Write("\\{0}/", new string('_', n / 2));
                if (n > 4)
                {
                    Console.Write("{0}", new string(' ', 2 * n - (2 * (n / 2) + 4)));
                }
                Console.WriteLine("\\{0}/", new string('_', n / 2));
            }
            else//Mid
            {
                if (i == n - 2 && n > 4)
                {
                    Console.WriteLine("|{0} {1} {0}|", new string(' ', n / 2), new string('_', 2 * n - (2 * (n / 2) + 4)));
                }
                else
                {
                    Console.WriteLine("|{0}|", new string(' ', (2 * n) - 2));
                }
            }
        }
    }
}
