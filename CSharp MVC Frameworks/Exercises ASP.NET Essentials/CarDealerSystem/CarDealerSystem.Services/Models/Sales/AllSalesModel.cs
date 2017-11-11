using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Sales
{
    public class AllSalesModel
    {
        public ICollection<BasicSaleInfoModel> Sales { get; set; }
    }
}