using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//11. Extract sentences by keyword
namespace ExtractSentencesByKeyword
{
    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string input = Console.ReadLine();
            string pattern = @"([^.!?]+)([\W])";
            Regex rgx = new Regex(pattern);
            string keyWordPattern = string.Format(@"(\b" + keyword + @"\b)");
            Regex rgxKeyW = new Regex(keyWordPattern);

            MatchCollection matches = rgx.Matches(input);
            
            foreach (Match match in matches)
            {
                if (rgxKeyW.IsMatch(match.Groups[1].Value))
                {
                    Console.WriteLine(match.Groups[1].Value.Trim());
                }
            }
        }
    }
}
