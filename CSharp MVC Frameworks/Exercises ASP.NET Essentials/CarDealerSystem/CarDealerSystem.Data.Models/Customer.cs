using System;
using System.Collections.Generic;

namespace CarDealerSystem.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Purchases { get; set; } = new List<Sale>();
    }
}