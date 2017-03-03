using SalesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SalesDBContext();
            context.Database.Initialize(true);

            /*The default is connectionString="data source=.\SQLEXPRESS" 
             change it if you use something else, and just run the program.
             It will create a database called SalesDB if it does not exist 
             and will seed it with data(the data is randomly generated, that's why it's gibberish).
             For problem 6 i used auto migrations but later disabled them 
             and used normal ones for the rest.
            */
        }
    }
}
