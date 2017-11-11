using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Parts
{
    public class AllPartsModel
    {
        public IEnumerable<PartListingModel> Parts { get; set; }
    }
}