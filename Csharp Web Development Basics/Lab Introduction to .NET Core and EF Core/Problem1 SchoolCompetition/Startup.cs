using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1_SchoolCompetition
{
    class Program
    {
        public static void Main(string[] args)
        {
            var studentsGrades = new Dictionary<string, int>();
            var studentCategories = new Dictionary<string, SortedSet<string>>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(" ");
                string name = tokens[0];
                string category = tokens[1];
                int score = int.Parse(tokens[2]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = 0;
                }

                if (!studentCategories.ContainsKey(name))
                {
                    studentCategories[name] = new SortedSet<string>();
                }

                studentsGrades[name] += score;
                studentCategories[name].Add(category);
            }

            var orderedStudents = studentsGrades
                .OrderByDescending(s => s.Value)
                .ThenBy(s => s.Key);

            foreach (var student in orderedStudents)
            {
                string categories = string.Join(", ", studentCategories[student.Key]);

                Console.WriteLine($"{student.Key}: {student.Value} [{categories}]");
            }
        }
    }
}