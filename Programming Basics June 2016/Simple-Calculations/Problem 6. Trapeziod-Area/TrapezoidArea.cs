using System;
//Problem 6: Trapezoid Area
class TrapezoidArea
{
    static void Main(string[] args)
    {
        double b1 = double.Parse(Console.ReadLine());
        double b2 = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double area = (b1 + b2) * h / 2;
        Console.WriteLine("Trapezoid = " + area);
    }
}
