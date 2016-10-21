using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//13. Query Mess
namespace QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            Regex rgx1 = new Regex(@"([^&?]+)=([^&?]+)");
            Regex rgx2 = new Regex(@"(\+|%20)");

            string input = Console.ReadLine();

            while (input != "END")
            {
                MatchCollection matches = rgx1.Matches(input);
                List<string> results = new List<string>();

                foreach (Match match in matches)
                {
                    string noSpaces = Regex.Replace(match.Groups[0].ToString(), @"(\+|%20)", " ");
                    noSpaces = Regex.Replace(noSpaces, @"\s+", " ");
                    results.Add(noSpaces);
                }
                Dictionary<string, List<string>> lineItems = new Dictionary<string, List<string>>();

                foreach (var result in results)
                {
                    string[] keyAndValue = result.Split('=').Select(x => x.Trim()).ToArray();
                    string key = keyAndValue[0];
                    string value = keyAndValue[1];

                    if (!lineItems.ContainsKey(key))
                    {
                        lineItems.Add(key, new List<string> { value });
                    }
                    else
                    {
                        lineItems[key].Add(value);
                    }
                }

                foreach (var keyAndValue in lineItems)
                {
                    Console.Write($"{keyAndValue.Key}=[{string.Join(", ", keyAndValue.Value)}]");
                }
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}
