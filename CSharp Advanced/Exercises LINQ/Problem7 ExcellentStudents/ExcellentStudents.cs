using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7_ExcellentStudents
{
    class ExcellentStudents
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
                var marks = new List<int>();

                for (int i = 2; i < tokens.Length; i++)
                {
                    var mark = int.Parse(tokens[i]);
                    marks.Add(mark);
                }
                students.Add(new Student(firstName, lastName, marks));

                input = Console.ReadLine();
            }

            students.Where(s => s.Marks.Any(m => m == 6))
                .ToList()
                .ForEach(st => Console.WriteLine($"{st.FistName} {st.LastName}"));
        }

        class Student
        {
            public Student(string firstName, string lastName, List<int> marks)
            {
                this.FistName = firstName;
                this.LastName = lastName;
                this.Marks = marks;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
            public ICollection<int> Marks { get; set; }
        }
    }
}