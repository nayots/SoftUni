using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12_Inferno3
{
    class Inferno3
    {
        private static Dictionary<string, List<int>> excluded = new Dictionary<string, List<int>>();

        private static void Main(string[] args)
        {
            var gems = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var command = Console.ReadLine();

            while (command != "Forge")
            {
                var tokens = command.Split(';');
                var type = tokens[1];
                var sumCheck = int.Parse(tokens[2]);
                if (tokens[0] == "Exclude")
                {
                    if (type == "Sum Left")
                    {
                        SumLeft(type + sumCheck.ToString(), gems, sumCheck);
                    }
                    else if (type == "Sum Right")
                    {
                        SumRight(type + sumCheck.ToString(), gems, sumCheck);
                    }
                    else if (type == "Sum Left Right")
                    {
                        SumLeftRight(type + sumCheck.ToString(), gems, sumCheck);
                    }
                }
                else if (tokens[0] == "Reverse")
                {
                    var key = type + sumCheck.ToString();

                    if (excluded.ContainsKey(key))
                    {
                        excluded.Remove(key);
                    }
                }

                command = Console.ReadLine();
            }

            List<int> exclusions = new List<int>();

            foreach (var kvp in excluded)
            {
                exclusions.AddRange(kvp.Value);
            }

            exclusions = exclusions.Distinct().ToList();

            var items = new List<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                if (!exclusions.Contains(i))
                {
                    items.Add(gems[i]);
                }
            }

            Console.WriteLine(string.Join(" ", items));
        }

        private static void SumLeftRight(string key, int[] gems, int sumCheck)
        {
            List<int> results = new List<int>();
            if (gems.Length < 2)
            {
                if (gems[0] == sumCheck)
                {
                    results.Add(0);
                }
            }
            else
            {
                for (int i = 0; i < gems.Length; i++)
                {
                    if (i == 0)
                    {
                        if (0 + gems[i] + gems[i + 1] == sumCheck)
                        {
                            results.Add(i);
                        }
                    }
                    else if (i == gems.Length - 1)
                    {
                        if (gems[i - 1] + gems[i] + 0 == sumCheck)
                        {
                            results.Add(i);
                        }
                    }
                    else
                    {
                        if (gems[i - 1] + gems[i] + gems[i + 1] == sumCheck)
                        {
                            results.Add(i);
                        }
                    }
                }
            }

            excluded[key] = results;
        }

        private static void SumRight(string key, int[] gems, int sumCheck)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < gems.Length; i++)
            {
                if (i == gems.Length - 1)
                {
                    if (gems[i] + 0 == sumCheck)
                    {
                        results.Add(i);
                    }
                }
                else
                {
                    if (gems[i] + gems[i + 1] == sumCheck)
                    {
                        results.Add(i);
                    }
                }
            }

            excluded[key] = results;
        }

        private static void SumLeft(string key, int[] gems, int sumCheck)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < gems.Length; i++)
            {
                if (i == 0)
                {
                    if (0 + gems[i] == sumCheck)
                    {
                        results.Add(i);
                    }
                }
                else
                {
                    if (gems[i - 1] + gems[i] == sumCheck)
                    {
                        results.Add(i);
                    }
                }
            }

            excluded[key] = results;
        }
    }
}