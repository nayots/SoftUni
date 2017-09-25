using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;
using StudentSystem.Models;
using System;
using System.Linq;

namespace StudentSystem.Client.Core
{
    public class Engine
    {
        public void Run()
        {
            using (var db = new StudentSystemContext())
            {
                SeedDbWithSampleData(db);

                //Tasks

                //1
                ListStudentsAndHomework(db);
                Console.WriteLine();
                //2
                ListCoursesAndResources(db);
                //3
                ListCoursesWithALotOfResources(db);
                Console.WriteLine();
                //4
                ListCoursesActiveOnDate(db, new DateTime(2015, 2, 1));
                Console.WriteLine();
                //5
                ListStudentCourseSummary(db);
                Console.WriteLine();
                //6
                ListAllCoursesResourcesAndLicenses(db);
                Console.WriteLine();
                //7
                ListStudentCoursesResourcesLicenses(db);
            }
        }

        private void ListStudentCoursesResourcesLicenses(StudentSystemContext db)
        {
            var studentsInfo = db.Students
                .Select(s => new
                {
                    s.Name,
                    CoursesCount = s.Courses.Count,
                    ResourcesCount = s.Courses.Sum(sc => sc.Course.Resources.Count),
                    LicensesCount = s.Courses
                                        .Sum(sc =>
                                                sc.Course.Resources
                                                .Sum(r =>
                                                        r.Licenses.Count
                                                     )
                                             )
                })
                .OrderByDescending(si => si.CoursesCount)
                .ThenByDescending(si => si.ResourcesCount)
                .ThenBy(si => si.Name)
                .ToList();

            foreach (var si in studentsInfo)
            {
                Console.WriteLine($"Student: {si.Name}");
                Console.WriteLine($"--Courses count: {si.CoursesCount}");
                Console.WriteLine($"--Resources count: {si.ResourcesCount}");
                Console.WriteLine($"--Licenses count: {si.LicensesCount}");
            }
        }

        private void ListAllCoursesResourcesAndLicenses(StudentSystemContext db)
        {
            var results = db.Courses
                .Select(c => new
                {
                    c.Name,
                    Resources = c.Resources.Select(r => new
                    {
                        ResourceName = r.Name,
                        Licenses = r.Licenses.Select(l => l.Name)
                    })
                    .OrderByDescending(r => r.Licenses.Count())
                    .ThenBy(r => r.ResourceName)
                })
                .ToList()
                .OrderByDescending(c => c.Resources.Count())
                .ThenBy(c => c.Name);

            foreach (var course in results)
            {
                Console.WriteLine($"Course: {course.Name}");
                foreach (var res in course.Resources)
                {
                    Console.WriteLine($"--Resource: {res.ResourceName}");
                    Console.WriteLine($"---Licenses: {(res.Licenses.Any() ? string.Join(", ", res.Licenses) : "None")}");
                }
            }
        }

        private void ListStudentCourseSummary(StudentSystemContext db)
        {
            var studentResults = db.Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    NumberOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Course.Price),
                    AveragePrice = s.Courses.Average(c => c.Course.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.NumberOfCourses)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var studentSummary in studentResults)
            {
                Console.WriteLine($"Student: {studentSummary.Name}");
                Console.WriteLine($"--Courses count: {studentSummary.NumberOfCourses}");
                Console.WriteLine($"--Total price: {studentSummary.TotalPrice:F2}");
                Console.WriteLine($"--Average price: {studentSummary.AveragePrice:F2}");
            }
        }

        private void ListCoursesActiveOnDate(StudentSystemContext db, DateTime activeDate)
        {
            var courses = db.Courses
                .Where(c => c.StartDate <= activeDate && c.EndDate >= activeDate)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = c.EndDate.Subtract(c.StartDate).TotalDays,
                    StudentsCount = c.Students.Count
                })
                .OrderByDescending(c => c.StudentsCount)
                .ThenByDescending(c => c.Duration)
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}");
                Console.WriteLine($"--Course start date: {course.StartDate.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"--Course end date: {course.EndDate.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"--Duration: {course.Duration} days");
                Console.WriteLine($"--Enrolled students: {course.StudentsCount}");
            }
        }

        private void ListCoursesWithALotOfResources(StudentSystemContext db)
        {
            var results = db.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourceCount = c.Resources.Count
                })
                .ToList();

            foreach (var course in results)
            {
                Console.WriteLine($"Course: {course.Name}{Environment.NewLine}Resources: {course.ResourceCount}");
            }
        }

        private void ListCoursesAndResources(StudentSystemContext db)
        {
            var results = db.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resources = c.Resources
                                 .Select(r => new
                                 {
                                     r.Name,
                                     r.ResourceType,
                                     r.Url
                                 })
                })
                .ToList();

            foreach (var course in results)
            {
                Console.WriteLine($"Course: {course.Name}");
                Console.WriteLine($"Description: {course.Description}");
                foreach (var res in course.Resources)
                {
                    Console.WriteLine($"-- Resource: {res.Name}");
                    Console.WriteLine($"-- Type: {res.ResourceType}");
                    Console.WriteLine($"-- Url: {res.Url}");
                }
                Console.WriteLine();
            }
        }

        private void ListStudentsAndHomework(StudentSystemContext db)
        {
            var results = db.Students
                .Select(s => new
                {
                    Name = s.Name,
                    Homework = s.Homework
                                .Select(hw => new
                                {
                                    hw.Content,
                                    hw.ContentType
                                })
                }).ToList();

            foreach (var student in results)
            {
                Console.WriteLine(student.Name);
                foreach (var hw in student.Homework)
                {
                    Console.WriteLine($"-- Content: {hw.Content}, type: {hw.ContentType}");
                }
            }
        }

        private void SeedDbWithSampleData(StudentSystemContext db)
        {
            var studentOne = new Student
            {
                Name = "Gosho",
                RegistrationDate = new DateTime(2000, 10, 19),
                Birthday = new DateTime(1989, 01, 01),
                PhoneNumber = "0887999123"
            };

            var studentTwo = new Student
            {
                Name = "Pesho",
                RegistrationDate = new DateTime(2001, 11, 20),
                Birthday = new DateTime(1989, 01, 01),
                PhoneNumber = "0887999123"
            };

            var studentThree = new Student
            {
                Name = "Ivan",
                RegistrationDate = new DateTime(2002, 12, 21),
                Birthday = new DateTime(1989, 01, 01),
                PhoneNumber = "0887999123"
            };

            var courseOne = new Course
            {
                Name = "C#",
                StartDate = new DateTime(2015, 01, 02),
                EndDate = new DateTime(2015, 02, 03),
                Price = 210M,
                Description = "A course about C#"
            };

            var courseTwo = new Course
            {
                Name = "Java",
                StartDate = new DateTime(2015, 05, 02),
                EndDate = new DateTime(2015, 06, 10),
                Price = 200M,
                Description = "Java stuff"
            };

            var courseThree = new Course
            {
                Name = "JS",
                StartDate = new DateTime(2015, 08, 02),
                EndDate = new DateTime(2015, 09, 12),
                Price = 150M,
                Description = "JavaScript things"
            };

            db.Students.Add(studentOne);
            db.Students.Add(studentTwo);
            db.Students.Add(studentThree);

            db.Courses.Add(courseOne);
            db.Courses.Add(courseTwo);
            db.Courses.Add(courseThree);

            db.SaveChanges();

            studentOne = db.Students
                 .Include(s => s.Courses)
                 .Include(s => s.Homework)
                 .FirstOrDefault(s => s.Name == "Gosho");

            studentTwo = db.Students
                 .Include(s => s.Courses)
                 .Include(s => s.Homework)
                 .FirstOrDefault(s => s.Name == "Pesho");

            studentThree = db.Students
                 .Include(s => s.Courses)
                 .Include(s => s.Homework)
                 .FirstOrDefault(s => s.Name == "Ivan");

            courseOne = db.Courses
                .Include(c => c.Students)
                .Include(c => c.Resources)
                .Include(c => c.HWSubmissions)
                .FirstOrDefault(c => c.Name == "C#");

            courseTwo = db.Courses
                .Include(c => c.Students)
                .Include(c => c.Resources)
                .Include(c => c.HWSubmissions)
                .FirstOrDefault(c => c.Name == "Java");

            courseThree = db.Courses
                .Include(c => c.Students)
                .Include(c => c.Resources)
                .Include(c => c.HWSubmissions)
                .FirstOrDefault(c => c.Name == "JS");

            studentOne.Courses.Add(new StudentCourse
            {
                CourseId = courseOne.Id
            });

            studentOne.Courses.Add(new StudentCourse
            {
                CourseId = courseThree.Id
            });

            studentTwo.Courses.Add(new StudentCourse
            {
                CourseId = courseTwo.Id
            });

            studentThree.Courses.Add(new StudentCourse
            {
                CourseId = courseOne.Id
            });

            studentThree.Courses.Add(new StudentCourse
            {
                CourseId = courseTwo.Id
            });

            studentThree.Courses.Add(new StudentCourse
            {
                CourseId = courseThree.Id
            });

            courseOne.Resources.Add(new Resource
            {
                Name = "SampleTextOne",
                ResourceType = Models.Enums.ResourceType.Document,
                Url = "www.softuni.bg"
            });

            courseOne.Resources.Add(new Resource
            {
                Name = "SampleTextTwo",
                ResourceType = Models.Enums.ResourceType.Document,
                Url = "www.softuni.bg"
            });

            courseOne.Resources.Add(new Resource
            {
                Name = "SampleTextThree",
                ResourceType = Models.Enums.ResourceType.Document,
                Url = "www.softuni.bg"
            });

            courseOne.Resources.Add(new Resource
            {
                Name = "SampleTextFour",
                ResourceType = Models.Enums.ResourceType.Document,
                Url = "www.softuni.bg"
            });

            courseOne.Resources.Add(new Resource
            {
                Name = "SampleTextFive",
                ResourceType = Models.Enums.ResourceType.Document,
                Url = "www.softuni.bg"
            });

            courseOne.Resources.Add(new Resource
            {
                Name = "SampleTextSix",
                ResourceType = Models.Enums.ResourceType.Document,
                Url = "www.softuni.bg"
            });

            courseTwo.Resources.Add(new Resource
            {
                Name = "SampleVideo",
                ResourceType = Models.Enums.ResourceType.Video,
                Url = "www.youtube.com"
            });

            courseThree.Resources.Add(new Resource
            {
                Name = "SimplePresentation",
                ResourceType = Models.Enums.ResourceType.Presentation,
                Url = "www.google.com"
            });

            studentOne.Homework.Add(new Homework
            {
                Content = "BlablaST1",
                ContentType = Models.Enums.ContentType.Pdf,
                SubmissionDate = new DateTime(2017, 10, 20),
                CourseId = courseOne.Id
            });

            studentOne.Homework.Add(new Homework
            {
                Content = "BlablaST12",
                ContentType = Models.Enums.ContentType.Zip,
                SubmissionDate = new DateTime(2017, 10, 25),
                CourseId = courseTwo.Id
            });

            studentTwo.Homework.Add(new Homework
            {
                Content = "BlablaST2",
                ContentType = Models.Enums.ContentType.Pdf,
                SubmissionDate = new DateTime(2017, 10, 2),
                CourseId = courseOne.Id
            });

            studentThree.Homework.Add(new Homework
            {
                Content = "BlablaST3",
                ContentType = Models.Enums.ContentType.Application,
                SubmissionDate = new DateTime(2017, 10, 10),
                CourseId = courseThree.Id
            });

            db.SaveChanges();

            var licenseOne = new License
            {
                Name = "SimpleResourceOne",
                ResourceId = 1
            };

            var licenseTwo = new License
            {
                Name = "SimpleResourceTwo",
                ResourceId = 1
            };

            var licenseThree = new License
            {
                Name = "SimpleResourceThree",
                ResourceId = 2
            };

            db.Licenses.Add(licenseOne);
            db.Licenses.Add(licenseTwo);
            db.Licenses.Add(licenseThree);

            db.SaveChanges();
        }
    }
}