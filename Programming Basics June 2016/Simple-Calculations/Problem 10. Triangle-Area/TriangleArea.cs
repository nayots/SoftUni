using System;
//Problem 10: Triangle Area
class TriangleArea
{
    static void Main(string[] args)
    {
        double a = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double area = a * h / 2;
        Console.WriteLine("Triangle area = {0}", Math.Round(area, 2));
    }
}
