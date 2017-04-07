using PhotographyWorkshops.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            DbInitializer.InitDb();

            Importer importer = new Importer();
            importer.ImportLenses();
            importer.ImportCameras();
            importer.ImportPhotographers();

            importer.ImportAccessories();
            importer.ImportWorkshops();

            Exporter exporter = new Exporter();
            exporter.ExportOrderedPhotographers();
            exporter.ExportLandscapePhotographers();
            exporter.ExportSameCamerasPhotographers();
            exporter.ExportWorkshopsByLocation();
        }
    }
}
