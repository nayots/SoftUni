using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem1_MatchCount
{
    class MatchCount
    {
        private static void Main(string[] args)
        {
            var word = Regex.Escape(Console.ReadLine());
            var text = Console.ReadLine();

            Regex rgx = new Regex(word);

            MatchCollection matches = rgx.Matches(text);

            Console.WriteLine(matches.Count);
        }
    }
}