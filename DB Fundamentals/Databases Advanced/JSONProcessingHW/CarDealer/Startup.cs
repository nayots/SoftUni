using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    class Startup
    {
        static void Main(string[] args)
        {
            /*SERVER USED IS .\SQLEXPRESS change it if you are using some other DB, 
             * strategy is DropAndCreateAlways,
             * Run the program and it will populate the DB 
             * and create => export all the json files in the Export folder
             * Since Visual Studio does not automaticly add/show new files in the folder,
             * you have to open it manually(right click and "Open Folder In File Explorer" )
             */

            //5.Car Dealer Import Data
            DataImport();

            //Car Dealer Query and Export Data
            //Query 1 – Ordered Customers
            OrderedCustomers();
            //Query 2 – Cars from make Toyota
            ToyotoCars();
            //Query 3 – Local Suppliers
            LocalSuppliers();
            //Query 4 – Cars with Their List of Parts
            CarsWithParts();
            //Query 5 – Total Sales by Customer
            SalesByCustomer();
            //Query 6 – Sales with Applied Discount
            SalesWithDiscount();
        }

        private static void SalesWithDiscount()
        {
            using (var context = new CarDealerContext())
            {
                var sales = context.Sales
                    .Select(s => new
                    {
                        car = new { Make = s.Car.Make, Model = s.Car.Model, TravelledDistance = s.Car.TravelledDistance },
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount,
                        Price = s.Car.Parts.Sum(p => p.Price),
                        PriceWithDiscount = (s.Car.Parts.Sum(p => p.Price) - (s.Car.Parts.Sum(p => p.Price) * s.Discount))
                    })
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                var json = JsonConvert.SerializeObject(sales, settings);

                File.WriteAllText(@"..\..\Exports\sales-discounts.json", json);
            }
        }

        private static void SalesByCustomer()
        {
            using (var context = new CarDealerContext())
            {
                var customers = context.Customers
                    .Where(c => c.CarsBought.Count >= 1)
                    .Select(s => new
                    {
                        FullName = s.Name,
                        BoughtCars = s.CarsBought.Count,
                        SpentMoney = s.CarsBought.Sum(c => c.Car.Parts.Sum(p => p.Price))
                    })
                    .OrderByDescending(o => o.SpentMoney)
                    .ThenByDescending(o => o.BoughtCars)
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var json = JsonConvert.SerializeObject(customers, settings);

                File.WriteAllText(@"..\..\Exports\customers-total-sales.json", json);
            }
        }

        private static void CarsWithParts()
        {
            using (var context = new CarDealerContext())
            {
                var carsAndParts = context.Cars
                    .Select(s => new
                    {
                        car = new { Make = s.Make, Model = s.Model, TravelledDistance = s.TravelledDistance },
                        parts = s.Parts.Select(p => new { Name = p.Name, Price = p.Price })
                    })
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                var json = JsonConvert.SerializeObject(carsAndParts, settings);

                File.WriteAllText(@"..\..\Exports\cars-and-parts.json", json);
            }
        }

        private static void LocalSuppliers()
        {
            using (var context = new CarDealerContext())
            {
                var suppliers = context.Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new { Id = s.Id, Name = s.Name, PartsCount = s.Parts.Count })
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                var json = JsonConvert.SerializeObject(suppliers, settings);

                File.WriteAllText(@"..\..\Exports\local-suppliers.json", json);
            }
        }

        private static void ToyotoCars()
        {
            using (var context = new CarDealerContext())
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(m => m.Model)
                    .ThenByDescending(d => d.TravelledDistance)
                    .Select(s => new { Id = s.Id, Make = s.Make, Model = s.Model, TravelledDistance = s.TravelledDistance })
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                var json = JsonConvert.SerializeObject(cars, settings);

                File.WriteAllText(@"..\..\Exports\toyota-cars.json", json);
            }
        }

        private static void OrderedCustomers()
        {
            using (var context = new CarDealerContext())
            {
                var customers = context.Customers
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .Select(s => new { Id = s.Id, Name = s.Name, BirthDate = s.BirthDate, IsYoungDriver = s.IsYoungDriver, Sales = s.CarsBought.Take(0) })
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                var json = JsonConvert.SerializeObject(customers, settings);

                File.WriteAllText(@"..\..\Exports\ordered-customers.json", json);
            }
        }

        private static void DataImport()
        {
            var jsonSuppliers = File.ReadAllText(@"..\..\Imports\suppliers.json");

            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(jsonSuppliers);

            var jsonParts = File.ReadAllText(@"..\..\Imports\parts.json");

            var parts = JsonConvert.DeserializeObject<List<Part>>(jsonParts);

            var jsonCars = File.ReadAllText(@"..\..\Imports\cars.json");

            var cars = JsonConvert.DeserializeObject<List<Car>>(jsonCars);

            var jsonCustomers = File.ReadAllText(@"..\..\Imports\customers.json");

            var customers = JsonConvert.DeserializeObject<List<Customer>>(jsonCustomers);

            using (var context = new CarDealerContext())
            {
                context.Suppliers.AddRange(suppliers);

                context.SaveChanges();

                suppliers = context.Suppliers.ToList();

                Random rnd = new Random();

                foreach (var part in parts)
                {
                    int randomSupplierIndex = rnd.Next(0, suppliers.Count - 1);

                    part.Supplier = suppliers[randomSupplierIndex];
                }

                context.Parts.AddRange(parts);

                context.SaveChanges();

                parts = context.Parts.ToList();

                foreach (var car in cars)
                {
                    int partsCount = rnd.Next(10, 20);

                    List<int> addedPartsIndexes = new List<int>();

                    while (addedPartsIndexes.Count <= partsCount)
                    {

                        int randomPartIndex = rnd.Next(0, parts.Count - 1);

                        while (addedPartsIndexes.Contains(randomPartIndex))
                        {
                            randomPartIndex = rnd.Next(0, parts.Count - 1);
                        }

                        addedPartsIndexes.Add(randomPartIndex);

                        car.Parts.Add(parts[randomPartIndex]);
                    }
                }

                context.Cars.AddRange(cars);

                context.SaveChanges();

                context.Customers.AddRange(customers);

                context.SaveChanges();

                cars = context.Cars.ToList();
                customers = context.Customers.ToList();

                List<Sale> sales = new List<Sale>();

                for (int i = 0; i < 100; i++)
                {
                    int randomCarIndex = rnd.Next(0, cars.Count - 1);
                    int randomCustomerIndex = rnd.Next(0, customers.Count - 1);
                    int discountMultiplier = rnd.Next(0, 10);

                    while (discountMultiplier == 5 || discountMultiplier == 7 || discountMultiplier == 9)
                    {
                        discountMultiplier = rnd.Next(0, 10);
                    }

                    Sale sale = new Sale
                    {
                        Car = cars[randomCarIndex],
                        Customer = customers[randomCustomerIndex],
                        Discount = (discountMultiplier * 5) / (decimal)100
                    };

                    sales.Add(sale);
                }

                context.Sales.AddRange(sales);

                context.SaveChanges();
            }
        }
    }
}
