using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10_PredicateParty
{
    class PredicateParty
    {
        private static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<List<string>, string, List<string>> strsWDouble = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].StartsWith(s))
                    {
                        w.Insert(i, w[i]);
                        i++;
                    }
                }

                return w;
            };

            Func<List<string>, string, List<string>> strsWRemove = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].StartsWith(s))
                    {
                        w.Remove(w[i]);
                        i--;
                    }
                }

                return w;
            };
            Func<List<string>, string, List<string>> endsWDouble = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].EndsWith(s))
                    {
                        w.Insert(i, w[i]);
                        i++;
                    }
                }

                return w;
            };

            Func<List<string>, string, List<string>> endsWRemove = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].EndsWith(s))
                    {
                        w.Remove(w[i]);
                        i--;
                    }
                }

                return w;
            };

            Func<List<string>, int, List<string>> lengthDouble = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].Length <= s)
                    {
                        w.Insert(i, w[i]);
                        i++;
                    }
                }

                return w;
            };

            Func<List<string>, int, List<string>> lengthRemove = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].Length <= s)
                    {
                        w.Remove(w[i]);
                        i--;
                    }
                }

                return w;
            };

            var command = Console.ReadLine();
            //Double, Remove
            // StartsWith {} , EndsWith {}, Length {}
            while (command != "Party!")
            {
                var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var action = tokens[0];
                var criteria = tokens[1];
                var argument = tokens[2];

                if (action == "Double")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            people = strsWDouble(people, argument);
                            break;

                        case "EndsWith":
                            people = endsWDouble(people, argument);
                            break;

                        case "Length":
                            people = lengthDouble(people, int.Parse(argument));
                            break;
                    }
                }
                else if (action == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            people = strsWRemove(people, argument);
                            break;

                        case "EndsWith":
                            people = endsWRemove(people, argument);
                            break;

                        case "Length":
                            people = lengthRemove(people, int.Parse(argument));
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}