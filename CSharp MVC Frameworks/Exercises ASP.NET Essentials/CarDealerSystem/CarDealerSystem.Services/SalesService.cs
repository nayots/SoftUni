using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Cars;
using CarDealerSystem.Services.Models.Customers;
using CarDealerSystem.Services.Models.Sales;
using CarDealerSystem.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace CarDealerSystem.Services
{
    public class SalesService : ISalesService
    {
        private readonly CarDealerDbContext db;

        public SalesService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void AddSale(int carId, int customerId, double discount)
        {
            this.db.Sales.Add(new Sale()
            {
                CarId = carId,
                CustomerId = customerId,
                Discount = discount
            });

            this.db.SaveChanges();
        }

        public DiscountedSalesModel AllDiscountedSales(double? discount)
        {
            var query = this.db.Sales.AsQueryable();

            if (discount != null)
            {
                query = query.Where(s => (s.Discount * 100) == discount.Value);
            }
            else
            {
                query = query.Where(s => (s.Discount * 100) > 0d);
            }

            var result = new DiscountedSalesModel()
            {
                Sales = query.Select(s => s.Id).ToList().Select(s => this.SaleDetails(s)).ToList()
            };

            return result;
        }

        public AllSalesModel AllSales()
        {
            var result = new AllSalesModel()
            {
                Sales = this.db.Sales.Select(s => new BasicSaleInfoModel()
                {
                    Id = s.Id,
                    Discount = s.Discount
                }).ToList()
            };

            return result;
        }

        public IEnumerable<CarAddSaleModel> GetCarSaleModels()
        {
            return this.db.Cars.Select(c => new CarAddSaleModel()
            {
                Id = c.Id,
                Name = c.Make + " " + c.Model
            });
        }

        public IEnumerable<CustomerAddSaleModel> GetCustomerSaleModels()
        {
            return this.db.Customers.Select(c => new CustomerAddSaleModel()
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public FinalizeSaleModel GetFinalizeSaleInfo(int? carId, int? customerId, double? discount)
        {
            var model = new FinalizeSaleModel();

            var carInfo = this.db.Cars.Where(c => c.Id == carId.Value)
                .Select(c => new
                {
                    Name = c.Make + " " + c.Model,
                    Price = c.Parts.Sum(cp => cp.Part.Price)
                }).FirstOrDefault();

            var customer = this.db.Customers.FirstOrDefault(c => c.Id == customerId.Value);

            model.CustomerId = customerId.Value;
            model.CustomerName = customer.Name;
            model.Discount = customer.IsYoungDriver ? discount.Value + 5d : discount.Value;
            model.NormalPrice = carInfo.Price;
            model.DiscountPrice = (decimal)((double)carInfo.Price * ((100d - model.Discount) / 100));
            model.CarName = carInfo.Name;
            model.CarId = carId.Value;
            model.IsYoungDriver = customer.IsYoungDriver;

            return model;
        }

        public SaleDetailsModel SaleDetails(int id)
        {
            if (!this.db.Sales.Any(s => s.Id == id))
            {
                return null;
            }

            var sale = this.db.Sales.FirstOrDefault(s => s.Id == id);
            this.db.Entry(sale).Reference(s => s.Car).Load();
            this.db.Entry(sale).Reference(s => s.Customer).Load();

            var result = new SaleDetailsModel()
            {
                CarMake = sale.Car.Make,
                CarModel = sale.Car.Model,
                CustomerName = sale.Customer.Name
            };

            return result;
        }
    }
}