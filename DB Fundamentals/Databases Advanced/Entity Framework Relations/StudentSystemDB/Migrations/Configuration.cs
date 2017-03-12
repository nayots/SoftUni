namespace StudentSystemDB.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemDB.StudentSystemDBContext>
    {
        private static Random random = new Random();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StudentSystemDB.StudentSystemDBContext";
        }

        protected override void Seed(StudentSystemDB.StudentSystemDBContext context)
        {
            //Start of random data seeding
            var students = new List<Student>();
            var courses = new List<Course>();
            var resources = new List<Resource>();
            var homeworkSub = new List<Homework>();

            while (students.Count < 100)
            {
                var student = new Student();

                student.Name = GenerateRandomString();
                student.PhoneNumber = GenerateRandomNumber();
                var date = GenerateRandomDate();
                student.Birthday = date;
                student.RegistrationDate = date.AddDays(random.Next(300,1200));


                students.Add(student);
            }

            while (resources.Count < 100)
            {
                var resource = new Resource();

                resource.Name = GenerateRandomString();
                int typeRandom = random.Next(1, 4);
                switch (typeRandom)
                {
                    case 1:
                        resource.ResourceType = ResourceType.document;
                        break;
                    case 2:
                        resource.ResourceType = ResourceType.other;
                        break;
                    case 3:
                        resource.ResourceType = ResourceType.presentation;
                        break;
                    case 4:
                        resource.ResourceType = ResourceType.video;
                        break;
                    default:
                        break;
                }
                resource.URL = $"www.{GenerateRandomString()}.com";

                resources.Add(resource);
            }

            while (homeworkSub.Count < 60)
            {
                var homework = new Homework();

                homework.Content = GenerateRandomString();
                int typeRandom = random.Next(1, 3);
                switch (typeRandom)
                {
                    case 1:
                        homework.ContentType = ContentType.application;
                        break;
                    case 2:
                        homework.ContentType = ContentType.pdf;
                        break;
                    case 3:
                        homework.ContentType = ContentType.zip;
                        break;
                    default:
                        break;
                }

                homework.SubmissionDate = GenerateRandomDate();

                homeworkSub.Add(homework);
            }

            while (courses.Count < 30)
            {
                var course = new Course();

                course.Name = GenerateRandomString();
                course.Description = GenerateRandomString();
                var date = GenerateRandomDate();
                course.StartDate = date;
                course.EndDate = date.AddDays(random.Next(100, 300));
                course.Price = (random.Next(1, 10000) * 1.36M);

                courses.Add(course);
            }

            foreach (Student stud in students)
            {
                int randomCourse = random.Next(0, courses.Count - 1);
                stud.Courses.Add(courses[randomCourse]);
                randomCourse = random.Next(0, courses.Count - 1);
                stud.Courses.Add(courses[randomCourse]);
            }

            foreach (Homework hw in homeworkSub)
            {
                int randomStudent = random.Next(0, students.Count - 1);
                hw.Student = students[randomStudent];
                int randomCourse = random.Next(0, courses.Count - 1);
                hw.Course = courses[randomCourse];
            }

            foreach (Resource res in resources)
            {
                int randomCourse = random.Next(0, courses.Count - 1);
                res.Course = courses[randomCourse];
            }

            foreach (var s in students)
            {
                context.Students.AddOrUpdate(s);
                context.SaveChanges();
            }

            foreach (var hw in homeworkSub)
            {
                context.HomeworkSubmissions.AddOrUpdate(hw);
                context.SaveChanges();
            }

            foreach (var res in resources)
            {
                context.Resources.AddOrUpdate(res);
                context.SaveChanges();
            }

            foreach (var course in courses)
            {
                context.Courses.AddOrUpdate(course);
                context.SaveChanges();
            }

            context.SaveChanges();

            //End of seeding with random data
        }

        private DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1990, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private string GenerateRandomNumber()
        {
            string result = string.Empty;

            string chars = "0123456789";

            while (result.Length < 10)
            {
                result += chars[random.Next(0, chars.Length)];
            }

            return result;
        }

        private string GenerateRandomString()
        {
            string result = string.Empty;

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            while (result.Length < 10)
            {
                result += chars[random.Next(0, chars.Length)];
            }

            return result;
        }
    }
}
