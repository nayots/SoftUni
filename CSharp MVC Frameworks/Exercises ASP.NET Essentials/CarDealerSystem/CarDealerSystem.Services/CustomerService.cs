using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Customers;
using CarDealerSystem.Web.Data;
using System;
using System.Linq;

namespace CarDealerSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void AddCustomer(AddCustomerModel model)
        {
            bool isYoungDriver = (DateTime.Now - model.Birthday).Value.Days < (365 * 2);

            this.db.Customers.Add(new Customer()
            {
                Name = model.Name,
                Birthday = model.Birthday,
                IsYoungDriver = isYoungDriver
            });

            this.db.SaveChanges();
        }

        public AllCustomersModel All(string order)
        {
            var query = db.Customers.Where(c => c.Birthday.HasValue).AsQueryable();

            if (string.Equals(order, "ascending", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(c => c.Birthday.Value).ThenBy(c => c.IsYoungDriver).AsQueryable();
            }
            else
            {
                query = query.OrderByDescending(c => c.Birthday.Value).ThenBy(c => c.IsYoungDriver).AsQueryable();
            }

            var result = new AllCustomersModel
            {
                AllCustomers = query.Select(c =>
                new CustomerModel
                {
                    Name = c.Name,
                    Birthday = c.Birthday,
                    IsYoungDriver = c.IsYoungDriver,
                    Id = c.Id
                }).ToList()
            };

            return result;
        }

        public CustomerEditDeleteModel GetUserEditDeleteModelById(int? id)
        {
            if (!this.db.Customers.Any(c => c.Id == id.Value))
            {
                return null;
            }

            return this.db.Customers.Where(c => c.Id == id).Select(c => new CustomerEditDeleteModel()
            {
                Id = c.Id,
                Birthday = c.Birthday,
                Name = c.Name
            }).FirstOrDefault();
        }

        public CustomerSummaryModel Summary(int id)
        {
            if (!this.db.Customers.Any(c => c.Id == id))
            {
                return null;
            }

            var customer = this.db.Customers.First(c => c.Id == id);
            this.db.Entry(customer).Collection(c => c.Purchases).Load();
            foreach (var sale in customer.Purchases)
            {
                this.db.Entry(sale).Reference(c => c.Car).Load();
                this.db.Entry(sale.Car).Collection(c => c.Parts).Load();
                foreach (var part in sale.Car.Parts)
                {
                    this.db.Entry(part).Reference(p => p.Part).Load();
                }
            }

            var result = new CustomerSummaryModel()
            {
                Name = customer.Name,
                CarsCount = customer.Purchases.Count,
                MoneySpent = customer.Purchases.Sum(p => p.Car.Parts.Sum(pp => pp.Part.Price))
            };

            return result;
        }

        public void UpdateCustomer(CustomerEditDeleteModel model)
        {
            if (!this.db.Customers.Any(c => c.Id == model.Id))
            {
                return;
            }

            var customer = this.db.Customers.FirstOrDefault(c => c.Id == model.Id);

            bool isYoungDriver = (DateTime.Now - model.Birthday).Value.Days < (365 * 2);

            customer.Name = model.Name;
            customer.Birthday = model.Birthday;
            customer.IsYoungDriver = isYoungDriver;
            this.db.SaveChanges();
        }
    }
}