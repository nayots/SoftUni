using System.Collections.Generic;
using System.Linq;

namespace MiniServer.Application.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Cakes = new List<Cake>();
        }

        public ICollection<Cake> Cakes { get; set; }

        public double GetTotalCakesCost()
        {
            double result = this.Cakes.Select(c => c.Price).DefaultIfEmpty().Sum();

            return result;
        }
    }
}