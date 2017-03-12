using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDB.Models
{
    public enum ContentType
    {
        application,
        pdf,
        zip
    }
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Minimum Length is 1 char!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Content type must be application, pdf or zip!")]
        public ContentType ContentType { get; set; }

        [Required(ErrorMessage = "Submission date is a required field!")]
        public DateTime SubmissionDate { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
