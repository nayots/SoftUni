using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDB
{
    class Startup
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Started....");

            var context = new StudentSystemDBContext();
            context.Database.Initialize(true);//Read description first

            stopwatch.Stop();
            Console.WriteLine($"Finished!\nTime elapsed: {stopwatch.Elapsed.TotalMilliseconds} milliseconds");
            //Exercise 1 and 2:
            //The data in the seed method in the Configuration seeds the database with random data, 
            //since the data is randomly generated it is 99.9 % sure that it will add it rather 
            //then update it since the chances of dublicate values is slim to none.
            //If you don't want the random data you can always hardcore some data in the generator methods in Configuration.cs, 
            //either way everything works with the data generation AddorUpdate


            //Exercise 3

            ////3.1
            //ListAllStudentsAndHw(context);

            ////3.2
            //ListAllCoursesWithResources(context);

            ////3.3
            //ListCoursesWithMoreThan5Resources(context);

            ////3.4
            //CoursesOnAGivenDate(context);

            ////3.5
            //StudentStats(context);

            //Exercise 4
            //You can take a look at Resource.cs License.cs and The Migration file.
            //There is also a handy diagram picture in the files.

        }

        private static void StudentStats(StudentSystemDBContext context)
        {
            var students = context.Students
                .OrderByDescending(x => x.Courses.Sum(z => z.Price))
                .ThenByDescending(c => c.Courses.Count)
                .ThenBy(s => s.Name)
                .ToList();

            Console.WriteLine($"Total students: {students.Count}");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Courses: {student.Courses.Count}, Price: {student.Courses.Sum(x => x.Price)}, Average: {student.Courses.Average(a => a.Price)}");
            }
        }

        private static void CoursesOnAGivenDate(StudentSystemDBContext context)
        {
            var date = context.Courses.Select(s => s.StartDate).OrderBy(x => x).Skip(2).FirstOrDefault();
            Console.WriteLine("Given date:" + date.ToString("dd/MM/yyyy"));
            var courses = context.Courses.Where(x => x.StartDate < date && x.EndDate > date).ToList();

            foreach (var course in courses.OrderByDescending(x => x.Students.Count).ThenByDescending(d => d.EndDate - d.StartDate))
            {
                Console.WriteLine($"Course name: {course.Name} Start: {course.StartDate.ToString("dd/MM/yyyy")} End: {course.EndDate.ToString("dd/MM/yyyy")} Duration {(course.EndDate - course.StartDate).Days} days Enrolled: {course.Students.Count}");
            }
        }

        private static void ListCoursesWithMoreThan5Resources(StudentSystemDBContext context)
        {
            var courses = context.Courses
                .Where(x => x.Resources.Count > 5)
                .OrderByDescending(j => j.Resources.Count)
                .ThenByDescending(sd => sd.StartDate)
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course name: {course.Name} | Resource count: {course.Resources.Count}");
            }
        }

        private static void ListAllCoursesWithResources(StudentSystemDBContext context)
        {
            var courses = context.Courses.ToList();

            foreach (var course in courses.OrderBy(x => x.StartDate).ThenByDescending(z => z.EndDate))
            {
                Console.WriteLine($"Course name: {course.Name}");
                Console.WriteLine($"Description: {course.Description}");
                Console.WriteLine("Resources:");
                foreach (var res in course.Resources)
                {
                    Console.WriteLine($"Name: {res.Name}, Type: {res.ResourceType}, Url: {res.URL}");
                }
            }
        }

        private static void ListAllStudentsAndHw(StudentSystemDBContext context)
        {
            var students = context.Students.ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"Student name: {student.Name}");
                Console.WriteLine("Homework:");
                foreach (var hw in student.Homework)
                {
                    Console.WriteLine($"{hw.Content} - {hw.ContentType}");
                }
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
