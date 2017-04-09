using PlanetHunters.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            Initializer.InitDB();
            //Default connection string is .\SQLEXPRESS Change it if you are using something else.
        }
    }
}
