using System.Collections.Generic;

namespace CarDealerSystem.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<PartCar> Parts { get; set; } = new List<PartCar>();

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}