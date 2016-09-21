using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n < 2)
        {
            Console.WriteLine("Not Prime");
            return;
        }

        bool prime = true;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                prime = false;
                Console.WriteLine("Not Prime");
                break;
            }
        }
        if (prime)
        {
            Console.WriteLine("Prime");
        }
    }
}
