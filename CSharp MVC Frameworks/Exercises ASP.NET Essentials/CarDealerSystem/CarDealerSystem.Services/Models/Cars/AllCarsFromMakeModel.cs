using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Cars
{
    public class AllCarsFromMakeModel
    {
        public ICollection<CarFromMakeModel> Cars { get; set; }
    }
}