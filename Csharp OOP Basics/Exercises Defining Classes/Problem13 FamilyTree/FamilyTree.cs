using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem13_FamilyTree
{
    class FamilyTree
    {
        private static void Main(string[] args)
        {
            string pattern = @"\b\d+\/\d+\/\d+";

            Regex rgx = new Regex(pattern);

            List<Person> people = new List<Person>();

            var key = Console.ReadLine();

            List<string> linkedInformation = new List<string>();
            List<string> unlinkedInformation = new List<string>();

            var input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains(" - "))
                {
                    unlinkedInformation.Add(input);
                }
                else
                {
                    linkedInformation.Add(input);
                }
            }

            for (int i = 0; i < linkedInformation.Count; i++)
            {
                var tokens = linkedInformation[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var fName = tokens[0];
                var lName = tokens[1];
                var date = tokens[2];

                people.Add(new Person(fName, lName, date));
            }

            for (int j = 0; j < unlinkedInformation.Count; j++)
            {
                Person parent = null;
                Person child = null;
                var tokens = unlinkedInformation[j].Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();

                if (rgx.IsMatch(tokens[0]))//It's a date
                {
                    parent = people.First(p => p.Date == tokens[0]);
                }
                else
                {
                    var nameTokens = tokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var fName = nameTokens[0];
                    var lName = nameTokens[1];

                    parent = people.First(p => p.FirstName == fName && p.LastName == lName);
                }

                if (rgx.IsMatch(tokens[1]))//It's a date
                {
                    child = people.First(p => p.Date == tokens[1]);
                }
                else
                {
                    var nameTokens = tokens[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var fName = nameTokens[0];
                    var lName = nameTokens[1];

                    child = people.First(p => p.FirstName == fName && p.LastName == lName);
                }

                parent.Children.Add(child);
                child.Parents.Add(parent);
            }

            Person target = null;

            if (rgx.IsMatch(key))
            {
                target = people.First(p => p.Date == key);
            }
            else
            {
                var tokens = key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                target = people.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);
            }

            Console.WriteLine(target.ToString());
            Console.WriteLine($"Parents:");
            foreach (var p in target.Parents)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine($"Children:");
            foreach (var c in target.Children)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}