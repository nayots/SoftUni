using System;
//10. Cube Properties
namespace CubeProperties
{
    class CubeProperties
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string property = Console.ReadLine();
            ResultMessage(side, property);
        }

        static void ResultMessage(double side, string property)
        {
            switch (property)
            {
                case "face":
                    Console.WriteLine("{0:F2}", CubeFaceDiagonals(side));
                    break;
                case "space":
                    Console.WriteLine("{0:F2}", CubeSpaceDiagonals(side));
                    break;
                case "volume":
                    Console.WriteLine("{0:F2}", CubeVolume(side));
                    break;
                case "area":
                    Console.WriteLine("{0:F2}", CubeSurfaceArea(side));
                    break;
            }
        }

        static double CubeFaceDiagonals(double side)
        {
            return Math.Sqrt(2 * Math.Pow(side, 2));
        }

        static double CubeSpaceDiagonals(double side)
        {
            return Math.Sqrt(3 * Math.Pow(side, 2));
        }

        static double CubeVolume(double side)
        {
            return Math.Pow(side, 3);
        }

        static double CubeSurfaceArea(double side)
        {
            return (6 * Math.Pow(side, 2));
        }
    }
}
