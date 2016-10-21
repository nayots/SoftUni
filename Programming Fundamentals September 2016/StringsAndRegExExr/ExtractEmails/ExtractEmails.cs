using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//10. ExtractEmails
namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> emails = new List<string>();
            foreach (Match match in matches)
            {
                    emails.Add(match.Value);
            }

            Console.WriteLine(string.Join("\n",emails));
        }
    }
}
