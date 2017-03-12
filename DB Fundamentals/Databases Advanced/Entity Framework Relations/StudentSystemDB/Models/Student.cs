using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDB.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
            this.Homework = new List<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Student name must be at least 1 char long!")]
        public string Name { get; set; }

        [MaxLength(12, ErrorMessage = "Max length is 12 chars!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Registration date is a required field!")]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homework { get; set; }
    }
}
