using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem3StudentsAndCourses.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<StudentsCourses> Courses { get; set; } = new List<StudentsCourses>();
    }
}