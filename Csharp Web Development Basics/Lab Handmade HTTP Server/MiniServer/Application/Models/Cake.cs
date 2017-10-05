using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.Application.Models
{
    public class Cake
    {
        public Cake(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public double Price { get; private set; }

        public override string ToString()
        {
            string result = $"<p>name: {this.Name}<br />price: {this.Price:F2}</p>";

            return result;
        }
    }
}