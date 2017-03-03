using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB.Models
{
    public class Product
    {
        public Product()
        {
            this.SalesOfProduct = new HashSet<Sale>();
            this.Description = "No description";
        }

        public Product(string name, double quantity, decimal price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.SalesOfProduct = new HashSet<Sale>();
            this.Description = "No description";
        }

        public Product(string name, double quantity, decimal price, string description)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.SalesOfProduct = new HashSet<Sale>();
            this.Description = description;
        }
        public Product(string name, double quantity, decimal price, HashSet<Sale> sales, string description)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.SalesOfProduct = sales;
            this.Description = description;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual HashSet<Sale> SalesOfProduct { get; set; }

        public string Description { get; set; }
    }
}
