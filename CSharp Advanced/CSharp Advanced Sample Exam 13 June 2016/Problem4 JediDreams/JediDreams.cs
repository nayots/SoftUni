using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem4_JediDreams
{
    class JediDreams
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Method> methods = new List<Method>();

            string mathodPattern = @"static\s+.*?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)\s*\(";

            var rgx = new Regex(mathodPattern);
            string invokesPatters = @"([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(";
            Regex rgx2 = new Regex(invokesPatters);
            var currentMethod = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (rgx.IsMatch(input))
                {
                    Match match = rgx.Match(input);

                    currentMethod = match.Groups[1].Value;

                    if (!methods.Any(x => x.Name == currentMethod))
                    {
                        methods.Add(new Method(currentMethod));
                    }
                }
                else if (rgx2.IsMatch(input))
                {
                    var matches = rgx2.Matches(input);
                    var index = methods.IndexOf(methods.First(x => x.Name == currentMethod));
                    foreach (Match ma in matches)
                    {
                        methods[index].Invokes.Add(ma.Groups[1].Value);
                    }
                }
            }

            foreach (var meth in methods.OrderByDescending(m => m.Invokes.Count).ThenBy(x => x.Name))
            {
                if (meth.Invokes.Count > 0)
                {
                    Console.WriteLine($"{meth.Name} -> {meth.Invokes.Count} -> {string.Join(", ", meth.Invokes.OrderBy(v => v))}");
                }
                else
                {
                    Console.WriteLine($"{meth.Name} -> None");
                }
            }
        }

        class Method
        {
            public Method(string name)
            {
                this.Name = name;
                this.Invokes = new List<string>();
            }

            public string Name { get; set; }
            public List<string> Invokes { get; set; }
        }
    }
}