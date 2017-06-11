using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem3_SeriesOfLetters
{
    class SeriesOfLetters
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var pattern = @"(.)\1+";
            Regex rgx = new Regex(pattern);

            var output = rgx.Replace(input, "$1");
            Console.WriteLine(output);
        }
    }
}