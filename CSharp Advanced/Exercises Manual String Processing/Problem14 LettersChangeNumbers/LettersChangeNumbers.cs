using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem14_LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b([a-zA-z])(\d+)([a-zA-z])\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            decimal sum = 0;

            foreach (Match match in matches)
            {
                char firstLetter = match.Value.First();
                char lastLetter = match.Value.Last();
                decimal number = decimal.Parse(Regex.Match(match.Value, @"\d+").Value);

                if (Regex.IsMatch(firstLetter.ToString(), @"[A-Z]"))
                {
                    int letterpos = firstLetter - 64;
                    number /= letterpos;
                }
                else
                {
                    int letterpos = firstLetter - 96;
                    number *= letterpos;
                }

                if (Regex.IsMatch(lastLetter.ToString(), @"[A-Z]"))
                {
                    int letterpos = lastLetter - 64;
                    number -= letterpos;
                }
                else
                {
                    int letterpos = lastLetter - 96;
                    number += letterpos;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}