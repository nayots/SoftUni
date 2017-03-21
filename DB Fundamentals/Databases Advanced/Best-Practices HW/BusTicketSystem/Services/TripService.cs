using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class TripService
    {
        public void ChangeStatus(int tripId, Status status)
        {
            using (var context = new BusTicketSystemContext())
            {
                Trip trip = context.Trips.FirstOrDefault(t => t.Id == tripId);

                Status oldStatus = trip.Status;

                trip.Status = status;

                int ticketCount = 0;

                ticketCount = context.Tickets.Where(t => t.TripId == tripId).Count();

                if (status == Status.arrived)
                {
                    ArrivedTrip arTrip = new ArrivedTrip
                    {
                        ActualArrivalTime = DateTime.Now,
                        OriginStation = trip.OriginStation,
                        DestinationStation = trip.DestinationStation,
                        PassengerCount = ticketCount
                    };

                    context.ArrivedTrips.Add(arTrip);
                }

                context.SaveChanges();

                Console.WriteLine($"Trip from {trip.OriginStation.Town.Name} to {trip.DestinationStation.Town.Name} on {trip.DepartureTime}");
                Console.WriteLine($"Status changed from {oldStatus} to {trip.Status}");
            }
        }
    }
}
