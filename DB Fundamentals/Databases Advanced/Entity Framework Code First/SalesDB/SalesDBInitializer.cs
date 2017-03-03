using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SalesDB.Models;
using System.Diagnostics;

namespace SalesDB
{
    public class SalesDBInitializer : CreateDatabaseIfNotExists<SalesDBContext>
    {
        private static Random random = new Random();
        protected override void Seed(SalesDBContext context)
        {
            Console.WriteLine("Seeding the database....");
            var timer = new Stopwatch();
            timer.Start();

            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            List<StoreLocation> locations = new List<StoreLocation>();
            List<Sale> sales = new List<Sale>();


            while (products.Count < 5)
            {
                Product product = new Product();

                product.Name = GenerateRandomString();

                product.Price = random.Next(1, 1234) * 1.36M;

                product.Quantity = random.Next(50, 100) / 2.56;

                products.Add(product);
            }

            while (customers.Count < 5)
            {
                Customer customer = new Customer(GenerateRandomString(), GenerateRandomString(), GenerateRandomString(), GenerateRandomString());
                customers.Add(customer);
            }

            while (locations.Count < 5)
            {
                StoreLocation location = new StoreLocation(GenerateRandomString());

                locations.Add(location);
            }

            while (sales.Count < 5)
            {
                Sale sale = new Sale();

                int randomSale = random.Next(0, products.Count);
                int randomCustomer = random.Next(0, customers.Count);
                int randomLocation = random.Next(0, locations.Count);

                sale.Product = products[randomSale];
                sale.Customer = customers[randomCustomer];
                sale.StoreLocation = locations[randomLocation];
                sale.Date = GenerateRandomDate();

                sales.Add(sale);
            }

            context.Products.AddRange(products);
            context.Customers.AddRange(customers);
            context.StoreLocations.AddRange(locations);
            context.Sales.AddRange(sales);

            

            context.SaveChanges();

            Console.WriteLine("Seeding done!");
            timer.Stop();
            Console.WriteLine($"Time elapsed: {timer.Elapsed}");
            base.Seed(context);
        }

        private DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1990, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private string GenerateRandomString()
        {
            string result = string.Empty;

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            while (result.Length < 10)
            {
                result += chars[random.Next(0, chars.Length)];
            }

            return result;
        }
    }
}
