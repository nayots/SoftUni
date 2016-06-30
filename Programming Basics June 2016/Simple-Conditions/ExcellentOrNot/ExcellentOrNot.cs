using System;
//ExcellentOrNot
class ExcellentOrNot
{
    static void Main(string[] args)
    {
        double inputNumber = double.Parse(Console.ReadLine());
        if (inputNumber >= 5.5)
        {
            Console.WriteLine("Excellent!");
        }
        else
        {
            Console.WriteLine("Not excellent.");
        }
    }
}
