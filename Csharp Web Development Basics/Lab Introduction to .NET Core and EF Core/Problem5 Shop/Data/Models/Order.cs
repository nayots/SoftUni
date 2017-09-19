using System.Collections.Generic;

namespace Problem5Shop.Data.Models
{
    public class Order
    {
        public Order(int customerId)
        {
            this.CustomerId = customerId;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ItemsOrders> Items { get; set; } = new List<ItemsOrders>();
    }
}