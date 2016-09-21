using System;
class Greeting
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Hello, {0} {1}. You are {2} years old.", firstName, lastName, age);
    }
}
