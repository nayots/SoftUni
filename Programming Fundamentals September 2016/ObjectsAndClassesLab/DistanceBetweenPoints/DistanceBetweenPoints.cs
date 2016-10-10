using System;
using System.Collections.Generic;
using System.Linq;
//04. Distance between Points
namespace DistanceBetweenPoints
{
    class DistanceBetweenPoints
    {
        static void Main(string[] args)
        {
            Point p1 = GetPoint();
            Point p2 = Point.GetPoint();
            double distance = Point.CalculateDistance(p1, p2);
            Console.WriteLine(distance);

        }
    }

    class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public static Point GetPoint()
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Point point = new Point() { x = input[0], y = input[1] };
            return point;
        }

        public static double CalculateDistance(Point p1, Point p2)
        {
            double deltaX = p1.x - p2.x;
            double deltaY = p1.y - p2.y;
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            return distance;
        }
    }
}
