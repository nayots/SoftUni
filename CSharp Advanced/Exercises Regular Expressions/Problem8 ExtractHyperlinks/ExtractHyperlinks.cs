using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem8_ExtractHyperlinks
{
    class ExtractHyperlinks
    {
        private static void Main(string[] args)
        {
            var pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""""]*)""|([^\s>]+))[^>]*>";

            var regx = new Regex(pattern);

            var input = Console.ReadLine();

            var sb = new StringBuilder();

            while (input != "END")
            {
                sb.AppendLine(input);

                input = Console.ReadLine();
            }

            var matches = regx.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                for (int group = 1; group <= 3; group++)
                {
                    if (match.Groups[group].Length > 0)
                    {
                        Console.WriteLine(match.Groups[group]);
                    }
                }
            }
        }
    }
}