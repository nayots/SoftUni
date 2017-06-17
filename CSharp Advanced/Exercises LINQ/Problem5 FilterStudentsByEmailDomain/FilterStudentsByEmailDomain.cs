using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_FilterStudentsByEmailDomain
{
    class FilterStudentsByEmailDomain
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
                var email = tokens[2];
                students.Add(new Student(firstName, lastName, email));

                input = Console.ReadLine();
            }

            students.Where(s => s.Email.ToLower().EndsWith(@"@gmail.com"))
                .ToList()
                .ForEach(st => Console.WriteLine($"{st.FistName} {st.LastName}"));
        }

        class Student
        {
            public Student(string firstName, string lastName, string email)
            {
                this.FistName = firstName;
                this.LastName = lastName;
                this.Email = email;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}