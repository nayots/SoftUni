using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem8_ExtractQuotations
{
    class ExtractQuotations
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"('|"")(.+?)\1";
            Regex rgx = new Regex(pattern);

            var match = rgx.Match(input);
            while (match.Success)
            {
                Console.WriteLine(match.Groups[2]);

                match = match.NextMatch();
            }
        }
    }
}