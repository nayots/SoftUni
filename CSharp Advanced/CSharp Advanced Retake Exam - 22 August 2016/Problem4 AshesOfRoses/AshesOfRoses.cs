using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem4_AshesOfRoses
{
    class AshesOfRoses
    {
        private static void Main(string[] args)
        {
            string pattern = @"\b^Grow <([A-Z][a-z]+)> <([a-zA-Z0-9]+)> (\d+)$";

            Regex rgx = new Regex(pattern);

            var regions = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "Icarus, Ignite!")
            {
                var match = rgx.Match(input);

                if (match.Success)
                {
                    var region = match.Groups[1].Value;
                    var color = match.Groups[2].Value;
                    var amount = long.Parse(match.Groups[3].Value);

                    if (regions.ContainsKey(region))
                    {
                        if (regions[region].ContainsKey(color))
                        {
                            regions[region][color] += amount;
                        }
                        else
                        {
                            regions[region].Add(color, amount);
                        }
                    }
                    else
                    {
                        regions.Add(region, new Dictionary<string, long>() { { color, amount } });
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var reg in regions.OrderByDescending(x => x.Value.Values.Sum(r => r)).ThenBy(w => w.Key))
            {
                Console.WriteLine(reg.Key);
                foreach (var colr in reg.Value.OrderBy(c => c.Value).ThenBy(cn => cn.Key))
                {
                    Console.WriteLine($"*--{colr.Key} | {colr.Value}");
                }
            }
        }
    }
}