using System;
//PasswordGuess
class PasswordGuess
{
    static void Main(string[] args)
    {
        string guessWord = Console.ReadLine();
        if (guessWord == "s3cr3t!P@ssw0rd")
        {
            Console.WriteLine("Welcome");
        }
        else
        {
            Console.WriteLine("Wrong password!");
        }
    }
}
