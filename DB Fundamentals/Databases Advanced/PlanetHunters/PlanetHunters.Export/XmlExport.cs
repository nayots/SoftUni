using PlanetHunters.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlanetHunters.Export
{
    public static class XmlExport
    {
        public static void Stars()
        {
            XElement xml = ExportQueries.Stars();

            xml.Save(@"..\..\..\PlanetHunters.Export\FileExports\stars.xml");
        }
    }
}
