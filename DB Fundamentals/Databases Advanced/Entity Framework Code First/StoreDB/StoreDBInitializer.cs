using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB
{
    public class StoreDBInitializer : DropCreateDatabaseIfModelChanges<StoreDBContext>
    {
        protected override void Seed(StoreDBContext context)
        {
            Product pOne = new Product("Kartof", "Billa", "blabla", 20.50M, 10.50, 3);
            Product pTwo = new Product("Morkov", "Lidl", "bloblo", 10.50M, 6.67, 9);
            Product pThree = new Product("Zele", "Fantastiko", "vegetable", 5.60M, 50, 2);

            context.Products.Add(pOne);
            context.Products.Add(pTwo);
            context.Products.Add(pThree);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
