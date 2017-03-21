using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public Customer()
        {
            this.Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [ForeignKey("HomeTown")]
        public int HomeTownId { get; set; }

        public virtual Town HomeTown { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        [Required]
        public virtual BankAccount BankAccount { get; set; }

        [NotMapped]
        public string Fullname => $"{this.FirstName} {this.LastName}";
    }
}
