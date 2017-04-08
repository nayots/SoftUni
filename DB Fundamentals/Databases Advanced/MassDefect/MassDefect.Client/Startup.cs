using MassDefect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            DbInitializer.InitDB();

            Importer.ImportSolarSystems();
            Importer.ImportStars();
            Importer.ImportPlanets();
            Importer.ImportPeople();
            Importer.ImportAnomalies();
            Importer.ImportAnomalyVictims();
            Importer.ImportNewAnomalies();

            Exporter.ExportPlanets();
            Console.WriteLine("Exported Planets.");
            Exporter.ExportPeople();
            Console.WriteLine("Exported People.");
            Exporter.ExportAnomaly();
            Console.WriteLine("Exported Anomaly.");
            Exporter.ExportAnomalies();
            Console.WriteLine("Exported Anomalies.");
        }
    }
}
