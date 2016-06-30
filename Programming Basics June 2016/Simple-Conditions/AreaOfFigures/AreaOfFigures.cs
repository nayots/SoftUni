using System;
//AreaOfFigures
class AreaOfFigures
{
    static void Main(string[] args)
    {
        string shape = Console.ReadLine();
        if (shape == "square")
        {
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine(a * a);
        }
        else if (shape == "rectangle")
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine(a * b);
        }
        else if (shape == "circle")
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.PI*(r * r));
        }
        else if (shape == "triangle")
        {
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine((h * b) / 2);
        }
    }
}
