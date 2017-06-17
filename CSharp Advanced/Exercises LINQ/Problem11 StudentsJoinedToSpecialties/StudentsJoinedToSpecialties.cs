using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem11_StudentsJoinedToSpecialties
{
    class StudentsJoinedToSpecialties
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<StudentSpeciality> studentSpecialities = new List<StudentSpeciality>();
            List<Student> students = new List<Student>();

            while (input != "Students:")
            {
                var tokens = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var speciality = tokens[0] + " " + tokens[1];
                var facNum = int.Parse(tokens[2]);

                studentSpecialities.Add(new StudentSpeciality(speciality, facNum));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int facNum = int.Parse(tokens[0].Trim());
                var firstName = tokens[1];
                var lastName = tokens[2];
                students.Add(new Student(firstName, lastName, facNum));

                input = Console.ReadLine();
            }

            var results = students.Join(studentSpecialities, s => s.FacNum, x => x.FacNum, (pk, fk) => new { FirstName = pk.FistName, LastName = pk.LastName, FacNum = pk.FacNum, Speciality = fk.SpecialtyName }).ToList();

            foreach (var student in results.OrderBy(st => st.FirstName))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.FacNum} {student.Speciality}");
            }
        }

        class StudentSpeciality
        {
            public StudentSpeciality(string firstName, int facNUm)
            {
                this.SpecialtyName = firstName;
                this.FacNum = facNUm;
            }

            public string SpecialtyName { get; set; }
            public int FacNum { get; set; }
        }

        class Student
        {
            public Student(string firstName, string lastName, int facNUm)
            {
                this.FistName = firstName;
                this.LastName = lastName;
                this.FacNum = facNUm;
            }

            public string FistName { get; set; }
            public string LastName { get; set; }
            public int FacNum { get; set; }
        }
    }
}