using System;
//CircleArea
class CircleArea
{
    static void Main()
    {
        //A=πr2
        double r = double.Parse(Console.ReadLine());
        double circleArea = Math.PI * (r * r);
        Console.WriteLine("{0:f12}", circleArea);
    }
}
