using System;
//Problem 3: InchesToCentimeters
class InchesToCentimeters
{
    static void Main(string[] args)
    {
        Console.Write("Inches = ");
        double inches = double.Parse(Console.ReadLine());
        double centimeters = inches * 2.54;
        Console.WriteLine("Centimeters = {0}", centimeters);
    }
}