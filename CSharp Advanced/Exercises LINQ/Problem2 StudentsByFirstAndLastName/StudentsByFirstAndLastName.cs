using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_StudentsByFirstAndLastName
{
    class StudentsByFirstAndLastName
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

            students
                .Where(s => s.FistName.CompareTo(s.LastName) == -1)
                .ToList()
                .ForEach(r => Console.WriteLine($"{r.FistName} {r.LastName}"));
        }
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