using PhotographersDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographersDB
{
    public class PhotographersInitializer : CreateDatabaseIfNotExists<PhotographersDBContext>
    {
        protected override void Seed(PhotographersDBContext context)
        {
            var ph1 = new Photographer()
            {
                Username = "Pesho",
                Password = "adasd",
                RegisterDate = new DateTime(2000, 3, 23),
                BirthDate = new DateTime(1991, 12, 20),
                Email = "dasdas@abv.bg"
            };

            var ph2 = new Photographer()
            {
                Username = "Gosho",
                Password = "123abc",
                RegisterDate = new DateTime(2001, 1, 21),
                BirthDate = new DateTime(1991, 12, 13),
                Email = "ggdfgdfgdf@gmail.com"
            };

            var ph3 = new Photographer()
            {
                Username = "Gesho",
                Password = "kjkjj",
                RegisterDate = new DateTime(1989, 11, 25),
                BirthDate = new DateTime(1991, 12, 23),
                Email = "oldfart@aol.com"
            };

            context.Photographers.Add(ph1);
            context.Photographers.Add(ph2);
            context.Photographers.Add(ph3);

            context.SaveChanges();


            base.Seed(context);
        }
    }
}
