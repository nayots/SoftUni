using Box.Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    class Startup
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            IList<Box<double>> boxes = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            var b = boxes.First();

            var element = double.Parse(Console.ReadLine());

            Console.WriteLine(b.Compare(boxes, element));
        }
    }
}