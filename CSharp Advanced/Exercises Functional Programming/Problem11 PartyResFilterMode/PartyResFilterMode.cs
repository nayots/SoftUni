using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem11_PartyResFilterMode
{
    class PartyResFilterMode
    {
        private static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var endWords = new List<string>();
            var startWords = new List<string>();
            var lens = new List<int>();
            var containsWord = new List<string>();

            var command = Console.ReadLine();

            while (command != "Print")
            {
                var tokens = command.Split(';');

                var com = tokens[0];
                var type = tokens[1];
                var parameter = tokens[2];

                if (com == "Add filter")
                {
                    switch (type)
                    {
                        case "Starts with":
                            startWords.Add(parameter);
                            break;

                        case "Ends with":
                            endWords.Add(parameter);
                            break;

                        case "Length":
                            lens.Add(int.Parse(parameter));
                            break;

                        case "Contains":
                            containsWord.Add(parameter);
                            break;
                    }
                }
                else if (com == "Remove filter")
                {
                    switch (type)
                    {
                        case "Starts with":
                            startWords.Remove(parameter);
                            break;

                        case "Ends with":
                            endWords.Remove(parameter);
                            break;

                        case "Length":
                            lens.Remove(int.Parse(parameter));
                            break;

                        case "Contains":
                            containsWord.Remove(parameter);
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var word in startWords)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].StartsWith(word))
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }

            foreach (var word in endWords)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].EndsWith(word))
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }

            foreach (var number in lens)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Length <= number)
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }

            foreach (var word in containsWord)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Contains(word))
                    {
                        people.Remove(people[i]);
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}