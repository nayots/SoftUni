using CarDealerSystem.Services.Models.Parts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Cars
{
    public class AddCarModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        [Display(Name = "Travelled Distance")]
        public long? TravelledDistance { get; set; }

        public List<int> Parts { get; set; } = new List<int>();

        public IEnumerable<PartSelectModel> AvailableParts { get; set; } = new List<PartSelectModel>();
    }
}