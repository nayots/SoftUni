using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_SortStudents
{
    class SortStudents
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
                students.Add(new Student(firstName, lastName));

                input = Console.ReadLine();
            }

            students.OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FistName)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st.FistName} {st.LastName}"));
        }

        class Student
        {
            public Student(string firstName, string lastName)
            {
                this.FistName = firstName;
                this.LastName = lastName;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
        }
    }
}