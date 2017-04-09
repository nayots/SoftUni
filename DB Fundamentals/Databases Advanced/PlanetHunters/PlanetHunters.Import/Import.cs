using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Import
{
    class Import
    {
        static void Main(string[] args)
        {
            JsonImport.Astronomers();
            JsonImport.Telescopes();
            JsonImport.Planets();
            XmlImport.Stars();
            XmlImport.Discoveries();
        }
    }
}
