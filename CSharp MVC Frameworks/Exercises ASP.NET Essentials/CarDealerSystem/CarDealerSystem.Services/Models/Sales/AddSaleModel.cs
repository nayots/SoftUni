using CarDealerSystem.Services.Models.Cars;
using CarDealerSystem.Services.Models.Customers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Sales
{
    public class AddSaleModel
    {
        [Required]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        public IEnumerable<CustomerAddSaleModel> Customers { get; set; } = new List<CustomerAddSaleModel>();

        [Required]
        [Display(Name = "Car")]
        public int? CarId { get; set; }

        public IEnumerable<CarAddSaleModel> Cars { get; set; } = new List<CarAddSaleModel>();

        [Required]
        [Range(0d, 100d)]
        public double? Discount { get; set; }
    }
}