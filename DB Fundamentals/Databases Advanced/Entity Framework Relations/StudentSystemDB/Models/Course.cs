using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDB.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
            this.Resources = new List<Resource>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Minimum Length is 1 char!")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is a required field!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is a required field!")]
        public DateTime EndDate { get; set; }

        private decimal price { get; set; }

        [Required]
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price can't be a negative number");
                }
                this.price = value;
            }
        }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
