using System;
//House
class House
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int stars = 1;
        if (n % 2 == 0)
        {
            stars = 2;
        }
        int dashes = (n - stars) / 2;
        for (int i = 0; i < (n + 1) / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', dashes), new string('*', stars));
            stars += 2;
            dashes--;
        }
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("|{0}|",new string('*',n - 2));
        }
    }
}
