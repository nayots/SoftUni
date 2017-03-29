using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    class Startup
    {
        static void Main(string[] args)
        {
            /*SERVER USED IS .\SQLEXPRESS change it if you are using some other DB, 
             * strategy is DropAndCreateAlways,
             * Run the program and it will populate the DB 
             * and create => export all the xml files in the Export folder
             * Since Visual Studio does not automaticly add/show new files in the folder,
             * you have to open it manually(right click and "Open Folder In File Explorer" )
             * Database name is "CarDealerXml"
             */
            Console.WriteLine("Creating and populating DB...");
            //5.Car Dealer Import Data
            DataImport();
            Console.WriteLine("Done");
            Console.WriteLine("Generating and exporting files...");
            ////Car Dealer Query and Export Data
            ////Query 1 – Cars
            AllCars();
            ////Query 2 – Cars from make Ferrari
            FerrariCars();
            ////Query 3 – Local Suppliers
            LocalSuppliers();
            ////Query 4 – Cars with Their List of Parts
            CarsWithParts();
            ////Query 5 – Total Sales by Customer
            SalesByCustomer();
            ////Query 6 – Sales with Applied Discount
            SalesWithDiscount();
            Console.WriteLine("Done");
        }

        private static void SalesWithDiscount()
        {
            using (var context = new CarDealerContext())
            {
                var sales = context.Sales
                    .Select(s => new SaleWithDiscountDTO
                    {
                        Car = new CarSalesDiscountDTO { Make = s.Car.Make, Model = s.Car.Model, TravelledDistance = s.Car.TravelledDistance },
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount,
                        Price = s.Car.Parts.Sum(p => p.Price),
                        DescountedPrice = (s.Car.Parts.Sum(p => p.Price) - (s.Car.Parts.Sum(p => p.Price) * s.Discount))
                    })
                    .ToList();

                var serializer = new XmlSerializer(sales.GetType(), new XmlRootAttribute("sales"));

                var writer = new StreamWriter(@"..\..\Exports\sales-discounts.xml");

                using (writer)
                {
                    serializer.Serialize(writer, sales);
                }
            }
        }

        private static void SalesByCustomer()
        {
            using (var context = new CarDealerContext())
            {
                var customers = context.Customers
                    .Where(c => c.CarsBought.Count >= 1)
                    .Select(s => new CustomerTotalSalesDTO
                    {
                        FullName = s.Name,
                        BoughtCars = s.CarsBought.Count,
                        SpentMoney = s.CarsBought.Sum(c => c.Car.Parts.Sum(p => p.Price))
                    })
                    .OrderByDescending(o => o.SpentMoney)
                    .ThenByDescending(o => o.BoughtCars)
                    .ToList();

                var serializer = new XmlSerializer(customers.GetType(), new XmlRootAttribute("customers"));

                var writer = new StreamWriter(@"..\..\Exports\customers-total-sales.xml");

                using (writer)
                {
                    serializer.Serialize(writer, customers);
                }
            }
        }

        private static void CarsWithParts()
        {
            using (var context = new CarDealerContext())
            {
                List<CarDTOv2> carsAndParts = context.Cars
                    .Select(s => new CarDTOv2
                    {
                        Make = s.Make,
                        Model = s.Model,
                        TravelledDistance = s.TravelledDistance,
                        Parts = s.Parts.Select(p => new PartDTO { Name = p.Name, Price = p.Price }).ToList()
                    })
                    .ToList();

                var serializer = new XmlSerializer(carsAndParts.GetType(), new XmlRootAttribute("cars"));

                var writer = new StreamWriter(@"..\..\Exports\cars-and-parts.xml");

                using (writer)
                {
                    serializer.Serialize(writer, carsAndParts);
                }
            }
        }

        private static void LocalSuppliers()
        {
            using (var context = new CarDealerContext())
            {
                var suppliers = context.Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new SupplierDTO { Id = s.Id, Name = s.Name, PartsCount = s.Parts.Count })
                    .ToList();

                var serializer = new XmlSerializer(suppliers.GetType(), new XmlRootAttribute("suppliers"));

                var writer = new StreamWriter(@"..\..\Exports\local-suppliers.xml");

                using (writer)
                {
                    serializer.Serialize(writer, suppliers);
                }
            }
        }

        private static void FerrariCars()
        {
            using (var context = new CarDealerContext())
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Ferrari")
                    .OrderBy(m => m.Model)
                    .ThenByDescending(d => d.TravelledDistance)
                    .Select(s => new FerrariCarDTO{ Id = s.Id, Model = s.Model, TravelledDistance = s.TravelledDistance })
                    .ToList();

                var serializer = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));

                var writer = new StreamWriter(@"..\..\Exports\ferrari-cars.xml");

                using (writer)
                {
                    serializer.Serialize(writer, cars);
                }
            }
        }

        private static void AllCars()
        {
            using (var context = new CarDealerContext())
            {
                List<CarDTO> cars = context.Cars
                    .Where(c => c.TravelledDistance > 2000000)
                    .OrderBy(o => o.Make)
                    .ThenBy(o => o.Model)
                    .Select(s => new CarDTO { Make = s.Make, Model = s.Model, TravelledDistance = s.TravelledDistance})
                    .ToList();

                var serializer = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));

                var writer = new StreamWriter(@"..\..\Exports\cars.xml");

                using (writer)
                {
                    serializer.Serialize(writer, cars);
                }
            }
        }

        private static void DataImport()
        {
            XDocument xmlSuppliers = XDocument.Load(@"..\..\Imports\suppliers.xml");

            var suppliers = new List<Supplier>();

            foreach (var supplier in xmlSuppliers.Root.Elements())
            {
                string name = null;
                bool isImporter = false;

                var nameAtr = supplier.Attribute("name");

                if (nameAtr != null)
                {
                    name = supplier.Attribute("name").Value;
                }

                var importerAtr = supplier.Attribute("is-importer");

                if (importerAtr != null)
                {
                    isImporter = bool.Parse(supplier.Attribute("is-importer").Value);
                }

                Supplier supp = new Supplier
                {
                    Name = name,
                    IsImporter = isImporter
                };

                suppliers.Add(supp);
            }

            XDocument xmlParts = XDocument.Load(@"..\..\Imports\parts.xml");

            var parts = new List<Part>();

            foreach (var part in xmlParts.Root.Elements())
            {
                string name = null;
                decimal price = 0;
                int quantity = 0;

                var nameAtr = part.Attribute("name");
                if (nameAtr != null)
                {
                    name = part.Attribute("name").Value;
                }

                var priceAtr = part.Attribute("price");
                if (priceAtr != null)
                {
                    price = decimal.Parse(part.Attribute("price").Value);
                }

                var quantityAtr = part.Attribute("quantity");
                if (quantityAtr != null)
                {
                    quantity = int.Parse(part.Attribute("quantity").Value);
                }

                Part newPart = new Part
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };

                parts.Add(newPart);
            }

            XDocument xmlCars = XDocument.Load(@"..\..\Imports\cars.xml");

            var cars = new List<Car>();

            foreach (var car in xmlCars.Root.Elements())
            {
                string make = null;
                string model = null;
                long distance = 0;

                var makeEle = car.Element("make");
                if (makeEle != null)
                {
                    make = car.Element("make").Value;
                }

                var modelEle = car.Element("model");
                if (modelEle != null)
                {
                    model = car.Element("model").Value;
                }

                var distanceEle = car.Element("travelled-distance");
                if (distanceEle != null)
                {
                    distance = long.Parse(car.Element("travelled-distance").Value);
                }

                Car c = new Car
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = distance
                };

                cars.Add(c);
            }

            XDocument xmlCustomers = XDocument.Load(@"..\..\Imports\customers.xml");

            var customers = new List<Customer>();

            foreach (var customer in xmlCustomers.Root.Elements())
            {
                string name = null;
                DateTime bDate = new DateTime();
                bool isYoung = false;

                var nameAtr = customer.Attribute("name");
                if (nameAtr != null)
                {
                    name = customer.Attribute("name").Value;
                }

                var bDateEle = customer.Element("birth-date");
                if (bDateEle != null)
                {
                    bDate = DateTime.Parse(customer.Element("birth-date").Value);
                }

                var isYoungEle = customer.Element("is-young-driver");
                if (isYoungEle != null)
                {
                    isYoung = bool.Parse(customer.Element("is-young-driver").Value);
                }

                Customer cust = new Customer
                {
                    Name = name,
                    BirthDate = bDate,
                    IsYoungDriver = isYoung
                };

                customers.Add(cust);
            }

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
