using CarDealerSystem.Services.Models.Suppliers;

namespace CarDealerSystem.Services.Contracts
{
    public interface ISupplierService
    {
        AllFilteredSuppliersModel AllFiltered(string region);

        AllSuppliersModel All();

        SupplierModifyModel GetEditModelById(int id);

        void EditSupplier(SupplierModifyModel supplierModifyModel);

        void DeleteById(int id);

        void AddSupplier(AddSupplierModel addSupplierModel);
    }
}