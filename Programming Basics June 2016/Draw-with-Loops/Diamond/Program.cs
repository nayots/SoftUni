using System;
//Diamond
class Diamond
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int dashes = (n - 1) / 2;
        int midDashes = 1;
        int stars = 1;
        int oddOrEven = 1;
        if (n % 2 == 0)
        {
            stars = 2;
            midDashes = 2;
            oddOrEven = 0;
        }
        if (n == 1)
        {
            Console.WriteLine("*");
        }
        else if (n == 2)
        {
            Console.WriteLine("**");
        }
        else
        {
            for (int i = 0; i < n / 2 + oddOrEven; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0}{1}{0}", new string('-', (n - 1) / 2), new string('*', stars));
                }
                else
                {
                    dashes--;
                    Console.WriteLine("{0}*{1}*{0}", new string('-', dashes), new string('-', midDashes));
                    midDashes += 2;
                }
            }
            dashes = 0;
            midDashes -= 2;

            for (int i = 0; i < (n + 1) / 2 - 2; i++)
            {
                dashes++;
                midDashes -= 2;
                Console.WriteLine("{0}*{1}*{0}", new string('-', dashes), new string('-', midDashes));
            }
            Console.WriteLine("{0}{1}{0}", new string('-', (n - 1) / 2), new string('*', stars));
        }
    }
}