using System;

namespace CarDealerSystem.Services.Models.Customers
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}