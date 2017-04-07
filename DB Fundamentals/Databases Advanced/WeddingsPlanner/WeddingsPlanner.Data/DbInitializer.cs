using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.Data
{
    public static class DbInitializer
    {
        public static void InitDb()
        {
            using (var context = new WeddingsPlannerContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
