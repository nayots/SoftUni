using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Export
{
    class Export
    {
        static void Main(string[] args)
        {
            string telescopeName = "TRAPPIST";
            string starSystemName = "Alpha Centauri";

            //Use this if you dont want the hardcoded values.

            //Console.WriteLine("Enter existing telescope name:");
            //telescopeName = Console.ReadLine();

            //Console.WriteLine("Enter existing starSystem name:");
            //starSystemName = Console.ReadLine();

            JsonExport.Planets(telescopeName);
            JsonExport.Astronomers(starSystemName);
            XmlExport.Stars();


            //Files are located in the FileExports folder of this project.
        }
    }
}
