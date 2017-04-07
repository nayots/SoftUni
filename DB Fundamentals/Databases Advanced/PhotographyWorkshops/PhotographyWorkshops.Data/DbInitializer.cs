using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Data
{
    public class DbInitializer
    {
        public static void InitDb()
        {
            using (var context = new PhotographyWorkshopsContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
