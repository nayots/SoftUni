using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Suppliers
{
    public class AllSuppliersModel
    {
        public IEnumerable<SupplierListModel> Suppliers { get; set; }
    }
}