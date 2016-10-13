using System;
using System.Collections.Generic;
using System.Linq;
//03.	Circles Intersection
namespace IntersectionOfCircles
{
    class IntersectionOfCircles
    {
        static void Main(string[] args)
        {
            Circle one = GetCircle();
            Circle two = GetCircle();
            double distance = GetDistance(one.point, two.point);
            if (distance <= one.r + two.r)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }


        public static double GetDistance(Point point1, Point point2)
        {
            double distance = Math.Sqrt(Math.Pow(point2.x - point1.x, 2) + Math.Pow(point2.y - point1.y, 2));
            return distance;
        }

        public static Circle GetCircle()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point point = new Point() { x = input[0], y = input[1] };
            Circle circle = new Circle() { point = point, r = input[2] };
            return circle;

        }
    }

    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    class Circle
    {
        public Point point { get; set; }
        public int r { get; set; }
    }
}
