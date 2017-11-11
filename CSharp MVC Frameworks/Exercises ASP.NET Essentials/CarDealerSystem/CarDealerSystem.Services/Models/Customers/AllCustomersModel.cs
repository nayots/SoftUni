using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Customers
{
    public class AllCustomersModel
    {
        public ICollection<CustomerModel> AllCustomers { get; set; }
    }
}