using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Parts
{
    public class EditDeletePartModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0d, double.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int? Quantity { get; set; }
    }
}