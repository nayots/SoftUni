using System;
class TrainingLab
{
    static void Main()
    {
        double w = double.Parse(Console.ReadLine())*100;
        double h = double.Parse(Console.ReadLine())*100;

        double a = w / 120;
        double b = (h - 100) / 70;
        int desks = (int)a * (int)b - 3;
        Console.WriteLine(desks);
    }
}
