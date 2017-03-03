using System.ComponentModel.DataAnnotations;

namespace StoreDB.Models
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, string distributorName, string description, decimal price, double weight, int quantity)
        {
            this.Name = name;
            this.DistributorName = distributorName;
            this.Description = description;
            this.Price = price;
            this.Weight = weight;
            this.Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [Required(ErrorMessage = "Product Name is required!")]
        public string Name { get; set; }

        [MinLength(1)]
        public string DistributorName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public int Quantity { get; set; }
    }
}
