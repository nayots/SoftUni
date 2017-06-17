using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_MinEvenNumber
{
    class MinEvenNumber
    {
        private static void Main(string[] args)
        {
            var num = Console.ReadLine().Split().Select(double.Parse).Where(n => n % 2 == 0).ToList();

            if (num.Count > 0)
            {
                Console.WriteLine("{0:F2}", num.Min());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}