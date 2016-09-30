using System;
//11. Geometry Calculator
namespace GeometryCalculator
{
    class GeometryCalculator
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            GeometricFigureSelector(figure);
        }

        static void GeometricFigureSelector(string figure)
        {
            switch (figure)//triangle, square, rectangle and circle
            {
                case "triangle":
                    TriangleCalculator();
                    break;
                case "square":
                    SquareCalculator();
                    break;
                case "rectangle":
                    RectangleCalculator();
                    break;
                case "circle":
                    CircleCalculator();
                    break;
            }
        }

        static void TriangleCalculator()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = side * height / 2;
            Console.WriteLine($"{area:F2}");
        }

        static void SquareCalculator()
        {
            double side = double.Parse(Console.ReadLine());
            double area = Math.Pow(side, 2);
            Console.WriteLine($"{area:F2}");
        }

        static void RectangleCalculator()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = width * height;
            Console.WriteLine($"{area:F2}");
        }

        static void CircleCalculator()
        {
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine($"{area:F2}");
        }
    }
}
