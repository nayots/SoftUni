using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new List<Category>();
        }

        private decimal price;

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

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
                    throw new ArgumentException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        
        public int? BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public User Buyer { get; set; }

        [Required]
        public int SellerId { get; set; }
        
        [ForeignKey("SellerId")]
        public User Seller { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
