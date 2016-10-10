using System;
using System.Collections.Generic;
using System.Linq;
//05. Closest Two Points
namespace ClosestTwoPoints
{
    class ClosestTwoPoints
    {
        static void Main(string[] args)
        {
            Point[] points = Point.GetPoints();
            Point[] closestPoints = Point.FindClosestPoints(points);
            Point.PrintDistance(closestPoints);
            Point.PrintPoint(closestPoints[0]);
            Point.PrintPoint(closestPoints[1]);
        }

        public class Point
        {
            public double x { get; set; }
            public double y { get; set; }

            public static Point[] FindClosestPoints(Point[] points)
            {
                double minDistance = double.MaxValue;
                Point[] closestTwoPoints = null;
                for (int pos1 = 0; pos1 < points.Length; pos1++)
                {
                    for (int pos2 = pos1 + 1; pos2 < points.Length; pos2++)
                    {
                        double dist = CalculateDistance(points[pos1], points[pos2]);
                        if (dist < minDistance)
                        {
                            minDistance = dist;
                            closestTwoPoints = new Point[] { points[pos1], points[pos2] };
                        }
                    }
                }
                return closestTwoPoints;
            }

            public static Point[] GetPoints()
            {
                int n = int.Parse(Console.ReadLine());

                Point[] points = new Point[n];

                for (int i = 0; i < n; i++)
                {
                    points[i] = GetPoint();
                }

                return points;
            }

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

            public static void PrintDistance(Point[] closestPoints)
            {
                double distance = CalculateDistance(closestPoints[0], closestPoints[1]);
                Console.WriteLine($"{distance:f3}");
            }

            public static void PrintPoint(Point point)
            {
                Console.WriteLine($"({point.x}, {point.y})");
            }
        }
    }
}
