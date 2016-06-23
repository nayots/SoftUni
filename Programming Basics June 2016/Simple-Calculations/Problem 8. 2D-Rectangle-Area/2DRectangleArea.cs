using System;
//Problem 8: 2D Rectangle Area
class TwoDRectangleArea
{
    static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double width = Math.Abs(x1 - x2);
        double length = Math.Abs(y1 - y2);
        Console.WriteLine(width * length);
        Console.WriteLine(2 * (width + length));
    }
}
