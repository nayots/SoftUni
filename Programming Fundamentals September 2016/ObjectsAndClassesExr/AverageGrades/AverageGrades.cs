using System;
using System.Collections.Generic;
using System.Linq;
//04. Average Grades
namespace AverageGrades
{
    class AverageGrades
    {
        static void Main(string[] args)
        {
            List<Student> students = GetStudents();
            PrintStudents(students);

        }

        private static void PrintStudents(List<Student> students)
        {
            foreach (Student stud in students.Where(x => x.AvrGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AvrGrade))
            {
                Console.WriteLine($"{stud.Name} -> {stud.AvrGrade:f2}");
            }
        }

        public static List<Student> GetStudents()
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student stud = new Student();
                List<string> input = Console.ReadLine().Split().ToList();
                stud.Name = input[0];
                input.RemoveAt(0);
                stud.Grades = input.Select(double.Parse).ToList();
                students.Add(stud);
            }

            return students;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AvrGrade
        {
            get
            {
                return Grades.Average();
            }
        }
    }
}
