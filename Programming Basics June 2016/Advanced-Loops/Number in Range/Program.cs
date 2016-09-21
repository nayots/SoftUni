using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        while (n < 1 || n > 100)
        {
            Console.WriteLine("Invalid number!"); ;
            n = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The number is: {0}",n);
    }
}