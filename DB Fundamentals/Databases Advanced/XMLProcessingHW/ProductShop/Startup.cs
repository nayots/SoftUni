using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.DTOs;

namespace ProductShop
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
            * Database name is "ProductShopXml"
            */

            Console.WriteLine("Creating and populating DB...");
            //3.Import data
            PopulateDB();
            Console.WriteLine("Done");
            Console.WriteLine("Generating and exporting files...");
            //Query and Export Data
            //Query 1 - Products In Range
            ProductsInRange();
            ////Query 2 - Successfully Sold Products
            UsersSoldProducts();
            ////Query 3 - Categories By Products Count
            CategoriesByProductsCount();
            ////Query 4 - Users and Products
            UsersAndProducts();
            Console.WriteLine("Done");
        }

        private static void UsersAndProducts()
        {
            using (var context = new ProductShopContext())
            {
                List<UsersAndProductsDTO> usersProducts = context.Users
                    .Where(u => u.ProductsSold.Count > 1)
                    .OrderByDescending(o => o.ProductsSold.Count)
                    .ThenBy(o => o.LastName)
                    .Select(z => new UsersAndProductsDTO
                    {
                        FirstName = z.FirstName,
                        LastName = z.LastName,
                        Age = z.Age,
                        ProductsSold = new SoldProductsDTO { Count = z.ProductsSold.Count(), SoldProducts = z.ProductsSold.Select(p => new SoldProductOneLineDTO { Name = p.Name, Price = p.Price }).ToList() }
                    })
                    .ToList();

                UsersProductsDTO usProd = new UsersProductsDTO
                {
                    users = usersProducts,
                    userCount = usersProducts.Count
                };

                var serializer = new XmlSerializer(usProd.GetType());

                var writer = new StreamWriter(@"..\..\Exports\users-and-products.xml");

                using (writer)
                {
                    serializer.Serialize(writer, usProd);
                }
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
                    .OrderByDescending(o => o.ProductsCount)
                    .Select(s => new CategoriesProductsDTO { Name = s.Category, ProductsCount = s.ProductsCount, AveragePrice = s.AveragePrice, TotalRevenue = s.TotalRevenue })
                    .ToList();



                var serializer = new XmlSerializer(categories.GetType(), new XmlRootAttribute("categories"));

                var writer = new StreamWriter(@"..\..\Exports\categories-by-products.xml");

                using (writer)
                {
                    serializer.Serialize(writer, categories);
                }
            }
        }

        private static void UsersSoldProducts()
        {
            using (var context = new ProductShopContext())
            {
                List<SellerDTO> users = context.Users
                    .Where(u => u.ProductsSold.Count > 1)
                    .Select(u => new SellerDTO
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u.ProductsSold
                                                     .Select(p => new SoldProductDTO
                                                     {
                                                         Name = p.Name,
                                                         Price = p.Price
                                                     }).ToList()
                    })
                    .OrderBy(o => o.LastName)
                    .ThenBy(o => o.FirstName)
                    .ToList();

                var serializer = new XmlSerializer(users.GetType(), new XmlRootAttribute("users"));

                var writer = new StreamWriter(@"..\..\Exports\users-sold-products.xml");

                using (writer)
                {
                    serializer.Serialize(writer, users);
                }
            }
        }

        private static void ProductsInRange()
        {
            using (var context = new ProductShopContext())
            {
                List<ProductInRangeDTO> products = context.Products
                    .Where(p => (p.Price >= 500 && p.Price <= 2000) && p.BuyerId != null)
                    .OrderBy(o => o.Price)
                    .Select(s => new { Name = s.Name, Price = s.Price, Seller = s.Seller.FirstName ?? "" + " " + s.Seller.LastName })
                    .ToList()
                    .Select(p => new { p.Name, p.Price, Seller = p.Seller.Trim() })
                    .Select(s => new ProductInRangeDTO { Name = s.Name, Price = s.Price, Seller = s.Seller })
                    .ToList();

                var serializer = new XmlSerializer(products.GetType(), new XmlRootAttribute("products"));

                var writer = new StreamWriter(@"..\..\Exports\products-in-range.xml");

                using (writer)
                {
                    serializer.Serialize(writer, products);
                }

            }
        }

        private static void PopulateDB()
        {

            XDocument xmlUsers = XDocument.Load(@"..\..\Imports\users.xml");

            var users = new List<User>();

            foreach (var user in xmlUsers.Root.Elements())
            {
                string firstName = null;
                string lastName = null;
                int age = 0;

                var fName = user.Attribute("first-name");

                if (fName != null)
                {
                    firstName = fName.Value;
                }

                var lName = user.Attribute("last-name");

                if (lName != null)
                {
                    lastName = lName.Value;
                }

                var ageE = user.Attribute("age");

                if (ageE != null)
                {
                    int.TryParse(user.Attribute("age").Value, out age);
                }

                User usr = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                users.Add(usr);
            }

            XDocument xmlProducts = XDocument.Load(@"..\..\Imports\products.xml");

            var products = new List<Product>();

            foreach (var prod in xmlProducts.Root.Elements())
            {
                string name = null;
                decimal price;

                name = prod.Element("name").Value;
                decimal.TryParse(prod.Element("price").Value, out price);

                Product product = new Product
                {
                    Name = name,
                    Price = price
                };

                products.Add(product);
            }

            XDocument xmlCategories = XDocument.Load(@"..\..\Imports\categories.xml");

            var categories = new List<Category>();

            foreach (var cat in xmlCategories.Root.Elements())
            {
                string name = null;

                name = cat.Element("name").Value;

                Category ca = new Category
                {
                    Name = name
                };

                categories.Add(ca);
            }



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
