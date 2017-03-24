using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Part
    {
        public Part()
        {
            this.Cars = new List<Car>();
        }

        private decimal price;
        [Key]
        public int Id { get; set; }
        [Required]
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
        [Required]
        public int Quantity { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
