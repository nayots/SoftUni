using System;
//Problem 11: CToF
class CToF
{
    static void Main(string[] args)
    {
        double celsius = double.Parse(Console.ReadLine());
        //°F = °C × 1,8 + 32
        double fahrenheit = celsius * 1.8 + 32;
        Console.WriteLine(Math.Round(fahrenheit, 2));
    }
}
