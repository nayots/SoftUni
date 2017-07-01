using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_ClassBox
{
    class ClassBox
    {
        private static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);
                box.PrintSurfaceArea();
                box.PrintLateralSurfaceArea();
                box.PrintVolume();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}