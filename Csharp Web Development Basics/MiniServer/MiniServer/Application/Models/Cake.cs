namespace MiniServer.Application.Models
{
    public class Cake
    {
        public Cake(int id, string name, double price)
        {
            this.Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public string GetHtml(string returnUrl)
        {
            string result = $"<p>name: {this.Name} ${this.Price:F2} <a href=\"/order?id={this.Id}\"><button>Order</button></a></p>";

            if (!string.IsNullOrEmpty(returnUrl))
            {
                result = $"<p>name: {this.Name} ${this.Price:F2} <a href=\"/order?id={this.Id}&returnUrl={returnUrl}\"><button>Order</button></a></p>";
            }

            return result;
        }

        public override string ToString()
        {
            string result = $"<p>{this.Name} - ${this.Price:F2}</p>";

            return result;
        }
    }
}