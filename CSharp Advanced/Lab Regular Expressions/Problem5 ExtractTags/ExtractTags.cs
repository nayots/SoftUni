using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem5_ExtractTags
{
    class ExtractTags
    {
        private static void Main(string[] args)
        {
            var pattern = @"\s*<.+?>";
            Regex rgx = new Regex(pattern);

            var input = Console.ReadLine();
            while (input != "END")
            {
                var match = rgx.Match(input);
                while (match.Success)
                {
                    Console.WriteLine(match.ToString().Trim());
                    match = match.NextMatch();
                }

                input = Console.ReadLine();
            }
        }
    }
}