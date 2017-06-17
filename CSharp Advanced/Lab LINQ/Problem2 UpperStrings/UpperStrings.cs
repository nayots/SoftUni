using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_UpperStrings
{
    class UpperStrings
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split().Select(w => w.ToUpper())));
        }
    }
}