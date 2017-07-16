using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterFactory
{
    public Harvester Get(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(arguments[4]));

            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);

            default:
                throw new ArgumentException("Harvester creation error.");
        }
    }
}