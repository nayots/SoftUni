using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Models;

namespace Client
{
    public class ChangeTripStatusCommand
    {
        private readonly TripService tripService;
        private readonly InfoService infoService;
        public ChangeTripStatusCommand(TripService tripService, InfoService infoService)
        {
            this.tripService = tripService;
            this.infoService = infoService;
        }

        public void Execute(string[] data)
        {
            int tripId;

            if (!int.TryParse(data[0], out tripId))
            {
                throw new ArgumentException($"{tripId} is not a valid input for trip id!");
            }

            Status status;

            if (!Enum.TryParse(data[1], out status))
            {
                throw new ArgumentException($"{data[1]} is not a valid input status!");
            }

            if (!infoService.TripExists(tripId))
            {
                throw new ArgumentException($"No trip with id({tripId}) was found!");
            }

            if (infoService.TripHasSameStatus(tripId, status))
            {
                throw new InvalidOperationException($"Trip with id({tripId}) is already marked as {status}");
            }

            tripService.ChangeStatus(tripId, status);
        }
    }
}
