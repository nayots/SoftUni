using System;
//Personal-Titles
class PersonalTitles
{
    static void Main(string[] args)
    {
        double age = double.Parse(Console.ReadLine());
        string sex = Console.ReadLine();
        if (age >= 16 && sex == "m")
        {
            Console.WriteLine("Mr.");
        }
        else if (age < 16 && sex == "m")
        {
            Console.WriteLine("Master");
        }
        else if (age >= 16 && sex == "f")
        {
            Console.WriteLine("Ms.");
        }
        else if (age < 16 && sex == "f")
        {
            Console.WriteLine("Miss");
        }
    }
}
