using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10_GroupByGroup
{
    class GroupByGroup
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
                    new { id = groupID, sts = studs.ToList() })
                .ToList();

            foreach (var group in res.OrderBy(x => x.id))
            {
                Console.WriteLine($"{group.id} - {string.Join(", ", group.sts.Select(st => st.FirstName + " " + st.LastName))}");
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