using System;
//01. Hello, Name!
namespace HelloName
{
    class HelloName
    {
        static void Main()
        {
            Console.WriteLine(GreetingGenerator(Console.ReadLine()));
        }

        static string GreetingGenerator(string name)
        {
            string greeting = $"Hello, {name}!";
            return greeting;
        }
    }
}
