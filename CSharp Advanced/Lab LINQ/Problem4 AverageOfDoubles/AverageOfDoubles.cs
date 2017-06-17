using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_AverageOfDoubles
{
    class AverageOfDoubles
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("{0:F2}", Console.ReadLine().Split().Select(double.Parse).Average());
        }
    }
}