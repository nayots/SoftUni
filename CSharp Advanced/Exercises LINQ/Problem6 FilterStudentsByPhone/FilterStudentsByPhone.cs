using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem6_FilterStudentsByPhone
{
    class FilterStudentsByPhone
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
                var phone = tokens[2];
                students.Add(new Student(firstName, lastName, phone));

                input = Console.ReadLine();
            }

            students.Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
                .ToList()
                .ForEach(st => Console.WriteLine($"{st.FistName} {st.LastName}"));
        }

        class Student
        {
            public Student(string firstName, string lastName, string phone)
            {
                this.FistName = firstName;
                this.LastName = lastName;
                this.Phone = phone;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
        }
    }
}