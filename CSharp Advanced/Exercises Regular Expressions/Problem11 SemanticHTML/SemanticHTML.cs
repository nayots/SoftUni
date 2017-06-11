using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem11_SemanticHTML
{
    class SemanticHTML
    {
        private static void Main(string[] args)
        {
            string[] tags = { "main", "header", "nav", "article", "section", "aside", "footer" };

            string openingTagsPattern = @"<div.*?\b((id|class)\s*=\s*""(.*?)"").*?>";
            Regex opRgx = new Regex(openingTagsPattern);
            string closingTagpattern = @"<\/div>\s.*?(\w+)\s*-->";
            Regex closeRgx = new Regex(closingTagpattern);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var openingTag = opRgx.Match(input);

                if (openingTag.Success)
                {
                    var name = openingTag.Groups[1].Value;
                    var value = openingTag.Groups[3].Value;
                    if (tags.Contains(value))
                    {
                        string replacement = openingTag.Groups[0].Value;
                        replacement = Regex.Replace(replacement, "div", value);
                        replacement = Regex.Replace(replacement, name, "");
                        replacement = Regex.Replace(replacement, @"\s*>", ">");
                        replacement = Regex.Replace(replacement, @"\s+", " ");
                        input = Regex.Replace(input, openingTag.Groups[0].Value, replacement);
                    }
                }

                var closingTag = closeRgx.Match(input);

                if (closingTag.Success)
                {
                    var name = closingTag.Groups[1].Value;

                    input = Regex.Replace(input, closingTag.Groups[0].Value, String.Format("</" + name + ">"));
                }
                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}