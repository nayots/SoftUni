using Problem5_Comparing_Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5_Comparing_Objects
{
    class Startup
    {
        private static void Main(string[] args)
        {
            string input = string.Empty;

            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }

            int n = int.Parse(Console.ReadLine()) - 1;

            var specialPerson = people[n];

            if (people.Where(x => x.CompareTo(specialPerson) == 0).Count() > 1)
            {
                int equalPeople = people.Where(p => p.CompareTo(specialPerson) == 0).Count();
                int unequalPeople = people.Where(p => p.CompareTo(specialPerson) != 0).Count();

                Console.WriteLine($"{equalPeople} {unequalPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}