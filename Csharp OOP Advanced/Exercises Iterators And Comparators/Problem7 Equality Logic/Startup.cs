using Problem7_Equality_Logic.Models;
using System;
using System.Collections.Generic;

namespace Problem7_Equality_Logic
{
    class Startup
    {
        private static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(tokens[0], int.Parse(tokens[1]));

                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine($"{sortedSet.Count}{Environment.NewLine}{hashSet.Count}");
        }
    }
}