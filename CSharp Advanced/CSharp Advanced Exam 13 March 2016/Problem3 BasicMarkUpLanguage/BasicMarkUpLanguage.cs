using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem3_BasicMarkUpLanguage
{
    class BasicMarkUpLanguage
    {
        private static void Main(string[] args)
        {
            string invPattern = @"^\s*<\s*inverse\s*content\s*=\s*""([\w\s]+)""\s*\/\s*>$";
            string revpattern = @"^\s*<\s*reverse\s*content\s*=\s*""(.+)""\s*\/\s*>$";
            string repPattern = @"^\s*<\s*repeat\s*value\s*=\s*""(\d+)""\s*content\s*=\s*""(.+)""\s*\/\s*>$";
            string stopPattern = @"^\s*<\s*stop\s*\/\s*>$";

            Regex invRgx = new Regex(invPattern);
            Regex revRgx = new Regex(revpattern);
            Regex repRgx = new Regex(repPattern);
            Regex stopRgx = new Regex(stopPattern);
            int counter = 1;

            while (true)
            {
                var input = Console.ReadLine();
                var content = string.Empty;
                var result = new StringBuilder();
                if (invRgx.IsMatch(input))
                {
                    var match = invRgx.Match(input);
                    content = match.Groups[1].Value;
                    foreach (var ch in content)
                    {
                        if (char.IsUpper(ch))
                        {
                            result.Append(char.ToLower(ch));
                        }
                        else
                        {
                            result.Append(char.ToUpper(ch));
                        }
                    }
                    Console.WriteLine($"{counter++}. {result.ToString()}");
                }
                else if (revRgx.IsMatch(input))
                {
                    var match = revRgx.Match(input);
                    content = match.Groups[1].Value;

                    var reversed = content.ToCharArray();
                    Array.Reverse(reversed);
                    result.Append(reversed);
                    Console.WriteLine($"{counter++}. {result.ToString()}");
                }
                else if (repRgx.IsMatch(input))
                {
                    var match = repRgx.Match(input);
                    var repetitions = int.Parse(match.Groups[1].Value);
                    content = match.Groups[2].Value;
                    for (int i = 0; i < repetitions; i++)
                    {
                        Console.WriteLine($"{counter++}. {content}");
                    }
                }
                else if (stopRgx.IsMatch(input))
                {
                    break;
                }
            }
        }
    }
}