using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Models
{
    public class Course
    {
        public const int MaxScoreOnExamTasks = 100;
        public const int NumberOfTasksOnExam = 5;

        private string name;
        private Dictionary<string, Student> studentsByName;

        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.name), ExceptionMessages.NullOrEmptyValue);
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get
            {
                return this.studentsByName;
            }
        }

        public void EntrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEntrolledInGivenCourse, student.UserName, this.name));
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}