using CarDealerSystem.Services.Models.Suppliers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Parts
{
    public class AddPartModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0d, double.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public int? SupplierId { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int? Quantity { get; set; } = 1;

        public IEnumerable<SupplierSelectModel> Suppliers { get; set; } = new List<SupplierSelectModel>();
    }
}