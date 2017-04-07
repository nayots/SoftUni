using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingsPlanner.Data;

namespace WeddingsPlanner.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            DbInitializer.InitDb();

            Importer.ImportAgencies();
            Console.WriteLine(new string('=',50)+ "\n");
            Importer.ImportPeople();
            Console.WriteLine(new string('=', 50) + "\n");
            Importer.ImportWeddingsAndInvitations();
            Console.WriteLine(new string('=', 50) + "\n");
            Importer.ImportVenues();
            Console.WriteLine(new string('=', 50) + "\n");
            Importer.ImportPresents();

            Console.WriteLine("Exporting Ordered Agencies");
            Exporter.OrderedAgencies();
            Console.WriteLine("Exporting Guest List");
            Exporter.GuestList();
            Console.WriteLine("Exporting Venues in Sofia");
            Exporter.VenuesSofia();
            Console.WriteLine("Exporting Agencies by town");
            Exporter.AgenciesByTown();
        }
    }
}
