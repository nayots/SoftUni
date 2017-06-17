using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_StudentsByAge
{
    class StudentsByAge
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
                int age = int.Parse(tokens[2]);
                students.Add(new Student(firstName, lastName, age));

                input = Console.ReadLine();
            }

            students.Where(s => s.Age >= 18 && s.Age <= 24)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st.FistName} {st.LastName} {st.Age}"));
        }

        class Student
        {
            public Student(string firstName, string lastName, int age)
            {
                this.FistName = firstName;
                this.LastName = lastName;
                this.Age = age;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}