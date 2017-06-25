using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_JediMeditation
{
    class JediMeditation
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> jedisM = new List<string>();
            List<string> jedisK = new List<string>();
            List<string> jedisP = new List<string>();
            List<string> jedisTS = new List<string>();

            bool yoda = false;

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');

                foreach (var j in tokens)
                {
                    string jediType = j[0].ToString();
                    if (jediType == "y")
                    {
                        yoda = true;
                        continue;
                    }
                    var level = int.Parse(j.Substring(1));

                    switch (jediType)
                    {
                        case "m":
                            jedisM.Add(j);
                            break;

                        case "k":
                            jedisK.Add(j);
                            break;

                        case "p":
                            jedisP.Add(j);
                            break;

                        case "t":
                            jedisTS.Add(j);
                            break;

                        case "s":
                            jedisTS.Add(j);
                            break;

                        default:
                            break;
                    }
                }
            }

            var results = new List<string>();

            if (yoda)
            {
                results.AddRange(jedisM);
                results.AddRange(jedisK);
                results.AddRange(jedisTS);
                results.AddRange(jedisP);
            }
            else
            {
                results.AddRange(jedisTS);
                results.AddRange(jedisM);
                results.AddRange(jedisK);
                results.AddRange(jedisP);
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}