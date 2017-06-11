using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem9_QueryMess
{
    class QueryMess
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string pattern = @"(\++|\s+|(%20)+)";
            Regex rgx = new Regex(pattern);

            while (input != "END")
            {
                Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
                input = Regex.Replace(input, pattern, " ");
                input = Regex.Replace(input, @"\s+", " ");
                input = Regex.Replace(input, @".*\?", "");
                var tokens = input.Split('&');
                foreach (var token in tokens)
                {
                    var keyAndValue = token.Split('=').Select(w => w.Trim()).ToArray();

                    if (pairs.ContainsKey(keyAndValue[0]))
                    {
                        pairs[keyAndValue[0]].Add(keyAndValue[1]);
                    }
                    else
                    {
                        pairs.Add(keyAndValue[0], new List<string>() { keyAndValue[1] });
                    }
                }
                foreach (var pair in pairs)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }
                Console.WriteLine();

                input = Console.ReadLine();
            }
        }
    }
}