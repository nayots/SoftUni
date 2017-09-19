using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem5Shop.Data.Models
{
    public class Salesman
    {
        public Salesman(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}