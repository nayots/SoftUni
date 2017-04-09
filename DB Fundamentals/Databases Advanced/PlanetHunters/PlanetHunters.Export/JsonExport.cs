using PlanetHunters.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Export
{
    public class JsonExport
    {
        public static void Planets(string telescopeName)
        {
            string json = ExportQueries.Planets(telescopeName);

            File.WriteAllText($@"..\..\..\PlanetHunters.Export\FileExports\planets-by-{telescopeName}.json", json);
        }

        public static void Astronomers(string starSystemName)
        {
            string json = ExportQueries.Astronomers(starSystemName);

            File.WriteAllText($@"..\..\..\PlanetHunters.Export\FileExports\astronomers-of-{starSystemName}.json", json);
        }
    }
}
