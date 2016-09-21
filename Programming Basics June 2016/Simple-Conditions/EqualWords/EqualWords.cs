using System;
//EqualWords
class EqualWords
{
    static void Main(string[] args)
    {
        string wordOne = Console.ReadLine().ToUpper();
        string wordTwo = Console.ReadLine().ToUpper();
        if (wordOne == wordTwo)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
