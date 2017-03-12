using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballDBData;
using FootballDBModels;

namespace FootballDBClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new FootballDBContext();

            context.Database.Initialize(true);

            //var goshoMomchetoLosho = context.Players.FirstOrDefault();
        }
    }
}
