using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem2_VowelCount
{
    class VowelCount
    {
        private const string vowels = "[aeiouy]";

        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex rgx = new Regex(vowels, RegexOptions.IgnoreCase);

            MatchCollection matches = rgx.Matches(input);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}