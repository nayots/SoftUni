using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Data
{
    public static class DbInitializer
    {
        public static void InitDB()
        {
            using (var context = new MassDefectContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
