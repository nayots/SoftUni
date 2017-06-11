using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem4_ExtractIntegers
{
    class ExtractIntegers
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\d+";

            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}