using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Suppliers
{
    public class SupplierModifyModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public bool Importer { get; set; }
    }
}