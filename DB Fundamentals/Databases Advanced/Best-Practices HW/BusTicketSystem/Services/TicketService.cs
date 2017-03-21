using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class TicketService
    {
        public void Buy(int customerId, int tripId, decimal price, string seatNumber)
        {
            using (var context = new BusTicketSystemContext())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.Id == customerId);

                Trip trip = context.Trips.FirstOrDefault(t => t.Id == tripId);

                Ticket ticket = new Ticket
                {
                    Customer = customer,
                    Trip = trip,
                    Price = price,
                    Seat = seatNumber
                };

                customer.BankAccount.Balance -= price;

                context.Tickets.Add(ticket);

                context.SaveChanges();

                Console.WriteLine($"Customer {customer.Fullname} bought a ticket for trip {tripId} for {price:F2} on seat {seatNumber}");
            }
        }
    }
}
