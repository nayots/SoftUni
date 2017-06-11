using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_StringLength
{
    class StringLength
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input.Length > 20)
            {
                input = input.Substring(0, 20);
            }

            Console.WriteLine(input.PadRight(20, '*'));
        }
    }
}