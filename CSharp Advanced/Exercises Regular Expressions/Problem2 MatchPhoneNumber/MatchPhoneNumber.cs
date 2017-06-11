using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem2_MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        private static void Main(string[] args)
        {
            string pattern = @"^\+359(-| )2\1\d{3}\1\d{3,4}$";

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