using System;
//EvenOrOdd
class EvenOrOdd
{
    static void Main(string[] args)
    {
        int userInput = int.Parse(Console.ReadLine());

        if (userInput % 2 == 0)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }
}
