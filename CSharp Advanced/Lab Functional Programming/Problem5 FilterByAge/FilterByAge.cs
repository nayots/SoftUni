using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_FilterByAge
{
    class FilterByAge
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(new[] { '\n', '\r', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                people.Add(new Person(data[0], int.Parse(data[1])));
            }

            var ageCondition = Console.ReadLine();
            var ageArg = int.Parse(Console.ReadLine());
            var formatArg = Console.ReadLine();

            PrintResults(people, ageCondition, ageArg, formatArg);
        }

        private static void PrintResults(List<Person> people, string ageCondition, int ageArg, string formatArg)
        {
            if (ageCondition == "older")
            {
                people = people.Where(p => p.Age >= ageArg).ToList();
            }
            else
            {
                people = people.Where(p => p.Age < ageArg).ToList();
            }

            var orderTokens = formatArg.Split();
            if (orderTokens.Length > 1)
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
            else
            {
                if (orderTokens[0] == "name")
                {
                    foreach (var person in people)
                    {
                        Console.WriteLine(person.Name);
                    }
                }
                else
                {
                    foreach (var person in people)
                    {
                        Console.WriteLine(person.Age);
                    }
                }
            }
        }
    }

    //2 classes in teh same file because SoftUni Judge sucks
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}