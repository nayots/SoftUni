using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
//08. MentorGroup
namespace MentorGroup
{
    class MentorGroup
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            students = GetStudentsInfo();
            PrintResults(students);
        }

        private static void PrintResults(List<Student> students)
        {
            foreach (var stud in students.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{stud.Name}");
                Console.WriteLine("Comments:");
                foreach (var com in stud.Comments)
                {
                    Console.WriteLine($"- {com}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var d in stud.Dates.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {d.ToString("dd/MM/yyyy")}");
                }
            }
        }

        private static List<Student> GetStudentsInfo()
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command != "end of dates")
            {
                List<string> usersDates = command.Split(',', ' ').ToList();
                string name = usersDates[0];
                usersDates.RemoveAt(0);
                List<DateTime> dates = usersDates.Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
                //dates = dates.Distinct().ToList();

                bool isRegistered = false;

                foreach (var stud in students)
                {
                    if (stud.Name == name)
                    {
                        isRegistered = true;
                        stud.Dates.AddRange(dates);
                        break;
                    }
                }
                if (isRegistered == false)
                {
                    Student student = new Student() { Name = name, Dates = dates , Comments = new List<string>()};
                    students.Add(student);
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "end of comments")
            {
                string[] comments = command.Split('-');
                string name = comments[0];
                string comment = comments[1];

                foreach (var stud in students)
                {
                    if (stud.Name == name)
                    {
                        stud.Comments.Add(comment);
                        break;
                    }
                }
                command = Console.ReadLine();
            }

            return students;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
