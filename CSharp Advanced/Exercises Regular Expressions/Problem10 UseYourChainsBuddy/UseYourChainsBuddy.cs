using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem10_UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex rgx = new Regex(@"<p>(.*?)<\/p>");

            MatchCollection matches = rgx.Matches(input);

            StringBuilder rawMessage = new StringBuilder();

            foreach (Match match in matches)
            {
                string treatedEntry = match.Groups[1].Value;
                treatedEntry = Regex.Replace(treatedEntry, @"[^a-z0-9]", " ");
                treatedEntry = Regex.Replace(treatedEntry, @"\s+", " ");
                rawMessage.Append(treatedEntry);
            }

            StringBuilder finalText = new StringBuilder();
            foreach (char cha in rawMessage.ToString())
            {
                char changedChar = cha;
                if (cha != ' ')
                {
                    if (cha >= 97 && cha <= 109)
                    {
                        changedChar = (char)(cha + 13);
                    }
                    else if (cha >= 110 && cha <= 122)
                    {
                        changedChar = (char)(cha - 13);
                    }
                }
                finalText.Append(changedChar);
            }

            Console.WriteLine(finalText);
        }
    }
}