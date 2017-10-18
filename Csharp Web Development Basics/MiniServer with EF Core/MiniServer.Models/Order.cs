using System;
using System.Collections.Generic;

namespace MiniServer.Models
{
    public class Order
    {
        public Order()
        {
        }

        public Order(DateTime creationDate)
        {
            this.CreationDate = creationDate;
        }

        public Order(DateTime creationDate, int userId)
        {
            this.CreationDate = creationDate;
            this.UserId = userId;
        }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    }
}