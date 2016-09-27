using System;
//6. Strings And Objects
class StringsAndObjects
{
    static void Main()
    {
        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        object concatenatedStrings = firstWord + " " + secondWord;
        string greeting = concatenatedStrings.ToString();
        Console.WriteLine(greeting);
    }
}
