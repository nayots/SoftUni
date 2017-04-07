using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingsPlanner.Models.enums;

namespace WeddingsPlanner.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(1)]
        [MaxLength(1)]
        [Required]
        public string MiddleInitial { get; set; }

        [MinLength(2)]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.MiddleInitial} {this.LastName}";
            }
        }

        [Required]
        public Gender Gender { get; set; }

        public DateTime? Birthdate { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (Birthdate == null) return null;
                DateTime now = DateTime.Now;
                int age = now.Year - this.Birthdate.Value.Year;

                if (now.Month < Birthdate.Value.Month || (now.Month == Birthdate.Value.Month && now.Day < Birthdate.Value.Day))
                {
                    age--;
                }

                return age;
            }
        }

        public string Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+\@[a-z]+\.[a-z]+$")]
        public string Email { get; set; }
    }
}
