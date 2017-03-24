using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class User
    {
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
            this.Friends = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        //[InverseProperty("Seller")]
        public virtual ICollection<Product> ProductsSold { get; set; }

        //[InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBought { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        [NotMapped]
        public string Fullname => $"{this.FirstName} {this.LastName}";
    }
}
