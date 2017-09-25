using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Homework> Homework { get; set; } = new List<Homework>();

        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}