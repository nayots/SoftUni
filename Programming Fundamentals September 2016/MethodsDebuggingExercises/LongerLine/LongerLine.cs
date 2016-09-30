using System;
//09. Longer Line
namespace LongerLine
{
    class LongerLine
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double lengthOfFirstPair = LineLength(x1, y1, x2, y2);
            double lengthOfSecondPair = LineLength(x3, y3, x4, y4);
            string result = "";
            if (lengthOfFirstPair >= lengthOfSecondPair)
            {
                result = closestPointToCenter(x1, y1, x2, y2);
                Console.WriteLine(result);
            }
            else
            {
                result = closestPointToCenter(x3, y3, x4, y4);
                Console.WriteLine(result);
            }
        }

        static double LineLength(double x1, double y1, double x2, double y2)
        {
            double differenceBetwenX = Math.Abs(x1 - x2);
            double differenceBetwenY = Math.Abs(y1 - y2);
            double line = Math.Sqrt(Math.Pow(differenceBetwenX,2)+ Math.Pow(differenceBetwenY,2));
            return line;
        }

        static string closestPointToCenter(double x1, double y1, double x2, double y2)
        {
            string coordinates = "";
            if (Math.Pow(x1, 2) + Math.Pow(y1, 2) <= Math.Pow(x2, 2) + Math.Pow(y2, 2))
            {
                coordinates = $"({x1}, {y1})({x2}, {y2})";
            }
            else
            {
                coordinates = $"({x2}, {y2})({x1}, {y1})";
            }
            return coordinates;
        }
    }
}
