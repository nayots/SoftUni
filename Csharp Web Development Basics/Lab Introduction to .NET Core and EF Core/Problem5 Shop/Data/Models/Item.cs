using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem5Shop.Data.Models
{
    public class Item
    {
        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<ItemsOrders> Orders { get; set; } = new List<ItemsOrders>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}