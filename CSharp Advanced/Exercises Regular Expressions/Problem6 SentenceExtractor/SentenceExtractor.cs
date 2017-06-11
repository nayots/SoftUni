using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem6_SentenceExtractor
{
    class SentenceExtractor
    {
        private static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string input = Console.ReadLine();
            string pattern = @"([^.!?]+)([\!\?\.])";
            Regex rgx = new Regex(pattern);
            string keyWordPattern = string.Format(@"(\b" + keyword + @"\b)");
            Regex rgxKeyW = new Regex(keyWordPattern);

            MatchCollection matches = rgx.Matches(input);

            foreach (Match match in matches)
            {
                if (rgxKeyW.IsMatch(match.Groups[1].Value))
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}