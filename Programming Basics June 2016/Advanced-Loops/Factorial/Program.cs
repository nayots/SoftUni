using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int num = 1;
        for (int i = 1; i <= n; i++)
        {
            num *= i;
        }
        Console.WriteLine(num);
    }
}
