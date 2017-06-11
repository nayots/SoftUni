using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem1_MatchFullName
{
    class MatchFullName
    {
        private static void Main(string[] args)
        {
            string pattern = @"\b[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+\b";

            Regex rgx = new Regex(pattern);

            var input = Console.ReadLine();

            while (input != "end")
            {
                var match = rgx.Match(input);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}