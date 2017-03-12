using PhotographersDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographersDB
{
    class Startup
    {
        static void Main(string[] args)
        {
            //Exercise 5 can be found in models
            //Exercise 6 can be found in models
            //Exercise 7 can be found in models
            //Exercise 8 is split into multiple files
            //Exercise 9 is in models again
            //Exercise 10 is also in models



            var context = new PhotographersDBContext();

            context.Database.Initialize(true);


            //Tag tag = new Tag
            //{
            //    Label = "#  tderp"//Change this for testing if you want
            //};

            //context.Tags.Add(tag);

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{

            //    tag.Label = TagTansformer.Transform(tag.Label);
            //    context.SaveChanges();
            //}

        }
    }
}
