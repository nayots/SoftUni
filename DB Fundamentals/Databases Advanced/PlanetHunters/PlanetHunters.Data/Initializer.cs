using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
{
    public static class Initializer
    {
        public static void InitDB()
        {
            using (var context = new PlanetHuntersContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
