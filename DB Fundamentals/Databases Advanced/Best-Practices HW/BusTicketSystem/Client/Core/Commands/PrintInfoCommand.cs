using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Client
{
    public class PrintInfoCommand
    {
        private readonly InfoService infoService;
        public PrintInfoCommand(InfoService infoService)
        {
            this.infoService = infoService;
        }

        public void Execute(string[] data)
        {
            int stationId;

            if (!int.TryParse(data[0], out stationId))
            {
                throw new ArgumentException($"{data[0]} is not a valid input for Id!");
            }

            if (!infoService.BusStationExsits(stationId))
            {
                throw new ArgumentException($"A station with id: {data[0]} does not exist!");
            }

            infoService.BusStationInfo(stationId);
        }
    }
}
