using CarDealerSystem.Services.Models.Cars;
using CarDealerSystem.Services.Models.Customers;
using CarDealerSystem.Services.Models.Sales;
using System.Collections.Generic;

namespace CarDealerSystem.Services.Contracts
{
    public interface ISalesService
    {
        AllSalesModel AllSales();

        SaleDetailsModel SaleDetails(int id);

        DiscountedSalesModel AllDiscountedSales(double? discount);

        IEnumerable<CarAddSaleModel> GetCarSaleModels();

        IEnumerable<CustomerAddSaleModel> GetCustomerSaleModels();

        FinalizeSaleModel GetFinalizeSaleInfo(int? carId, int? customerId, double? discount);

        void AddSale(int carId, int customerId, double discount);
    }
}