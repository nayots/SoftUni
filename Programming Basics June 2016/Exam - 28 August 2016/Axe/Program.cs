using System;
//Axe
class Axe
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int rows = 0;
        if (n % 2 == 0)
        {
            rows = n * 2;
        }
        else
        {
            rows = (n * 2) - 1;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}*{1}*{2}", new string('-', n * 3), new string('-', i), new string('-', (2 * n) - (2 + i)));
        }
        for (int k = 0; k < n / 2; k++)
        {
            Console.WriteLine("{0}*{1}*{1}", new string('*', n * 3), new string('-', n - 1));
        }

        for (int l = 0; l < n / 2; l++)
        {
            if (l == ((n / 2) - 1))
            {
                Console.WriteLine("{0}*{1}*{2}", new string('-', (n * 3) - l), new string('*', (n - 1) + (2 * l)), new string('-', (n - 1) - l));
            }
            else
            {
                Console.WriteLine("{0}*{1}*{2}", new string('-', (n * 3) - l), new string('-', (n - 1) + (2 * l)), new string('-', (n - 1) - l));
            }

        }
    }
}
