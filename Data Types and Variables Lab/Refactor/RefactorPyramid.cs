using System;
class Refactor
{
    static void Main()
    {
        Console.Write("Length: ");
        double length = double.Parse(Console.ReadLine());
        Console.Write("Width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Height: ");
        double heigth = double.Parse(Console.ReadLine());
        double volume = (length * width * heigth) / 3;
        Console.WriteLine("Pyramid Volume: {0:F2}", volume);
    }
}
