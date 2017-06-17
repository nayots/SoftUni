using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_StudentsByGroup
{
    class StudentsByGroup
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0];
                var lastName = tokens[1];
                int groupId = int.Parse(tokens[2]);
                students.Add(new Student(firstName, lastName, groupId));

                input = Console.ReadLine();
            }

            var res = students
                .GroupBy(g => g.GroupId, g =>
                    new { FirstName = g.FistName, LastName = g.LastName },
                    (groupID, studs) =>
                    new { gr = groupID, sts = studs.ToList() })
                .Where(group => group.gr == 2)
                .SelectMany(x => x.sts)
                .ToList();

            foreach (var stud in res.OrderBy(o => o.FirstName))
            {
                Console.WriteLine($"{stud.FirstName} {stud.LastName}");
            }
        }

        class Student
        {
            public Student(string firstName, string lastName, int groupId)
            {
                this.FistName = firstName;
                this.LastName = lastName;
                this.GroupId = groupId;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
            public int GroupId { get; set; }
        }
    }
}