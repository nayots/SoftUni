using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem4_ReplaceATag
{
    class ReplaceATag
    {
        private static void Main(string[] args)
        {
            string pattern = @"\s*<a href=""(.+)"">(.+)<\/a>";

            var input = Console.ReadLine();
            Regex rgx = new Regex(pattern);

            while (input != "end")
            {
                var match = rgx.Match(input);
                if (match.Success)
                {
                    input = rgx.Replace(input, "[URL href=\"$1\"]$2[/URL]");
                }
                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}