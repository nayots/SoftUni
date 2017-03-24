using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace ProductShop
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

            //2.Import data
            PopulateDB();

            //Query and Export Data
            //Query 1 - Products In Range
            ProductsInRange();
            //Query 2 - Successfully Sold Products
            SuccessfullySoldProducts();
            //Query 3 - Categories By Products Count
            CategoriesByProductsCount();
            //Query 4 - Users and Products
            UsersAndProducts();


        }

        private static void UsersAndProducts()
        {
            using (var context = new ProductShopContext())
            {
                var usersProducts = context.Users
                    .Where(u => u.ProductsSold.Count > 1)
                    .OrderByDescending(o => o.ProductsSold.Count)
                    .ThenBy(o => o.LastName)
                    .Select(z => new
                    {
                        FirstName = z.FirstName,
                        LastName = z.LastName,
                        Age = z.Age,
                        SoldProducts = new { Count = z.ProductsSold.Count(), Products = z.ProductsSold.Select(p => new { Name = p.Name, Price = p.Price }) }
                    })
                    .ToList();



                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var usersProductsJson = JsonConvert.SerializeObject(new { UsersCount = usersProducts.Count, Users = usersProducts }, settings);

                File.WriteAllText(@"..\..\Exports\users-and-products.json", usersProductsJson);
            }
        }

        private static void CategoriesByProductsCount()
        {
            using (var context = new ProductShopContext())
            {
                var categories = context.Categories
                    .Select(c => new
                    {
                        Category = c.Name,
                        ProductsCount = c.Products.Count(),
                        AveragePrice = (decimal?)c.Products.Average(a => a.Price),
                        TotalRevenue = (decimal?)c.Products.Sum(s => s.Price)
                    }
                            )
                    .OrderBy(o => o.Category)
                    .ToList();



                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var categoriesJson = JsonConvert.SerializeObject(categories, settings);

                File.WriteAllText(@"..\..\Exports\categories-by-products.json", categoriesJson);
            }
        }

        private static void SuccessfullySoldProducts()
        {
            using (var context = new ProductShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Count > 1)
                    .Select(u => new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u.ProductsSold
                                                     .Select(p => new
                                                     {
                                                         Name = p.Name,
                                                         Price = p.Price,
                                                         BuyerFirstName = p.Buyer.FirstName,
                                                         BuyerLastName = p.Buyer.LastName
                                                     })
                    })
                    .OrderBy(o => o.LastName)
                    .ThenBy(o => o.FirstName)
                    .ToList();



                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var usersJson = JsonConvert.SerializeObject(users, settings);

                File.WriteAllText(@"..\..\Exports\users-sold-products.json", usersJson);
            }
        }

        private static void ProductsInRange()
        {
            using (var context = new ProductShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(o => o.Price)
                    .Select(s => new { Name = s.Name, Price = s.Price, Seller = s.Seller.FirstName ?? "" + " " + s.Seller.LastName })
                    .ToList()
                    .Select(p => new { p.Name, p.Price, Seller = p.Seller.Trim() })
                    .ToList();



                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var productsJson = JsonConvert.SerializeObject(products, settings);

                File.WriteAllText(@"..\..\Exports\products-in-range.json", productsJson);
            }
        }

        private static void PopulateDB()
        {


            var jsonUsers = File.ReadAllText(@"..\..\Imports\users.json");

            var users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);

            var jsonProducts = File.ReadAllText(@"..\..\Imports\products.json");

            var products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);

            var jsonCategories = File.ReadAllText(@"..\..\Imports\categories.json");

            var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);

            using (var context = new ProductShopContext())
            {
                context.Users.AddRange(users);

                context.SaveChanges();
            }

            using (var context = new ProductShopContext())
            {
                context.Categories.AddRange(categories);

                context.SaveChanges();
            }

            Random rnd = new Random();

            using (var context = new ProductShopContext())
            {
                var dbUsers = context.Users.ToList();

                var dbcategories = context.Categories.ToList();

                int noBuyerCount = 0;

                foreach (var product in products)
                {
                    int randomUser = rnd.Next(0, dbUsers.Count - 1);

                    product.Seller = dbUsers[randomUser];

                    randomUser = rnd.Next(0, dbUsers.Count - 1);



                    if (noBuyerCount > 5)
                    {
                        product.Buyer = dbUsers[randomUser];
                    }

                    int catCount = rnd.Next(1, 3);

                    for (int i = 0; i < catCount; i++)
                    {
                        int randomCategory = rnd.Next(0, dbcategories.Count - 1);

                        product.Categories.Add(dbcategories[randomCategory]);
                    }
                    noBuyerCount++;
                }

                context.Products.AddRange(products);

                context.SaveChanges();
            }
        }
    }
}
