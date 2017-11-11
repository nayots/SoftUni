using CarDealerSystem.Services.Models.Customers;

namespace CarDealerSystem.Services.Contracts
{
    public interface ICustomerService
    {
        AllCustomersModel All(string order);

        CustomerSummaryModel Summary(int id);

        void AddCustomer(AddCustomerModel model);

        CustomerEditDeleteModel GetUserEditDeleteModelById(int? id);

        void UpdateCustomer(CustomerEditDeleteModel model);
    }
}