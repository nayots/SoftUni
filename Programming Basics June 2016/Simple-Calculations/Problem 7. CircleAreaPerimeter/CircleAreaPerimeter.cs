using System;
//Circle Area and Perimeter
class CircleAreaPerimeter
{
    static void Main(string[] args)
    {
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("Area = {0}",Math.PI * r * r);
        Console.WriteLine("Perimeter = {0}", 2 * Math.PI * r);
    }
}
