using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_KnightsOfHonor
{
    class KnightsOfHonor
    {
        private static void Main(string[] args)
        {
            Action<string> printSir = (x) => Console.WriteLine(string.Concat("Sir ", x));

            Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(w => printSir(w));
        }
    }
}