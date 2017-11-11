using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Suppliers
{
    public class AddSupplierModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public bool Importer { get; set; }
    }
}