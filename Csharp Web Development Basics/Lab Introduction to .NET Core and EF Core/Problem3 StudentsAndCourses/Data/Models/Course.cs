using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem3StudentsAndCourses.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<StudentsCourses> Students { get; set; } = new List<StudentsCourses>();
    }
}