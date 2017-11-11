using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Sales
{
    public class DiscountedSalesModel
    {
        public ICollection<SaleDetailsModel> Sales { get; set; }
    }
}