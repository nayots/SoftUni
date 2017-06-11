using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem5_ExtractEmail
{
    class ExtractEmail
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            string pattern = @"(?<=\s|^)[a-z0-9]+(?:[-._][a-z0-9]+)*@[a-z0-9]+(?:[-][a-z0-9]*)*\.[a-z]+(?:\.[a-z]+)*";

            Regex rgx = new Regex(pattern);

            var match = rgx.Match(input);

            while (match.Success)
            {
                Console.WriteLine(match);

                match = match.NextMatch();
            }
        }
    }
}