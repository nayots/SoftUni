using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class InfoService
    {
        public virtual void BusStationInfo(int stationId)
        {
            using (var context = new BusTicketSystemContext())
            {
                var station = context.BusStations.FirstOrDefault(s => s.Id == stationId);

                Console.WriteLine($"{station.Name}, {station.Town.Name}");

                var arrivals = station.TripsArriving.ToList();
                var departures = station.TripsDeparting.ToList();

                Console.WriteLine("Arrivals:");

                foreach (var arrival in arrivals)
                {
                    Console.WriteLine($"From {arrival.OriginStation.Name} | Arrive at: {arrival.ArrivalTime} | Status: {arrival.Status}");
                }
                Console.WriteLine("Departures:");
                foreach (var departure in departures)
                {
                    Console.WriteLine($"To {departure.DestinationStation.Name} | Depart at: {departure.DepartureTime} | Status: {departure.Status}");
                }
            }
        }

        public bool TripHasSameStatus(int tripId, Status status)
        {
            using (var context = new BusTicketSystemContext())
            {
                Trip trip = context.Trips.FirstOrDefault(t => t.Id == tripId);

                if (trip.Status == status)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool BusCompanyExists(int busCompanyId)
        {
            using (var context = new BusTicketSystemContext())
            {
                return context.BusCompanies.Any(b => b.Id == busCompanyId);
            }
        }

        public bool BusCompanyExists(string busCompanyName)
        {
            using (var context = new BusTicketSystemContext())
            {
                return context.BusCompanies.Any(b => b.Name == busCompanyName);
            }
        }

        public bool CustomerExists(int customerId)
        {
            using (var context = new BusTicketSystemContext())
            {
                return context.Customers.Any(c => c.Id == customerId);
            }
        }

        public bool TripExists(int tripId)
        {
            using (var context = new BusTicketSystemContext())
            {
                return context.Trips.Any(t => t.Id == tripId);
            }
        }

        public bool CustomerHasEnoughMoney(int customerId, decimal price)
        {
            using (var context = new BusTicketSystemContext())
            {
                decimal customerBalance = context.Customers.FirstOrDefault(c => c.Id == customerId).BankAccount.Balance;

                if (customerBalance - price >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool BusStationExsits(int stationId)
        {
            using (var context = new BusTicketSystemContext())
            {
                return context.BusStations.Any(s => s.Id == stationId);
            }
        }
    }
}
