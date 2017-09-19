using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem5Shop.Data.Models
{
    public class Customer
    {
        public Customer(string name, int salesmanId)
        {
            this.Name = name;
            this.SalesmanId = salesmanId;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int SalesmanId { get; set; }

        public Salesman Salesman { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}