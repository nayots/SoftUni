using System.Collections.Generic;

namespace MiniServer.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, double price, string imagePath = @"https://res.cloudinary.com/fehbot/image/upload/v1507579827/Random/miniCake.png")
        {
            Name = name;
            Price = price;
            this.ImagePath = imagePath;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public ICollection<OrderProduct> Orders { get; set; } = new List<OrderProduct>();

        public string GetHtml(string returnUrl)
        {
            string result = $"<p><a href=\"/cakeDetails/{this.Id}\">{this.Name}</a> ${this.Price:F2} <a href=\"/order?id={this.Id}&returnUrl={returnUrl}\"><button>Order</button></a></p>";

            if (string.IsNullOrEmpty(returnUrl))
            {
                result = $"<p><a href=\"/cakeDetails/{this.Id}\">{this.Name}</a> ${this.Price:F2} <a href=\"/order?id={this.Id}\"><button>Order</button></a></p>";
            }

            return result;
        }

        public string GetProductLink()
        {
            string result = $"<a href=\"/cakeDetails/{this.Id}\">{this.Name}</a>";

            return result;
        }

        public override string ToString()
        {
            string result = $"<p><a href=\"/cakeDetails/{this.Id}\">{this.Name}</a> - ${this.Price:F2}</p>";

            return result;
        }
    }
}