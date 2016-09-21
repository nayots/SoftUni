using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        Console.WriteLine(sum);
    }
}
