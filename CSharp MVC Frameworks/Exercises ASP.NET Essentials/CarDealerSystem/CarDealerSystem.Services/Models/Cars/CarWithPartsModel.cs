using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Cars
{
    public class CarWithPartsModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<PartModel> Parts { get; set; }
    }
}