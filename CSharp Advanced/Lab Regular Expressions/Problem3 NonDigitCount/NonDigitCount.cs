using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem3_NonDigitCount
{
    class NonDigitCount
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"\D";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}