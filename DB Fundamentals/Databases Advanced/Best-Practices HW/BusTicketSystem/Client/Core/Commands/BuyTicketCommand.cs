using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Client
{
    public class BuyTicketCommand
    {
        private readonly TicketService ticketService;
        private readonly InfoService infoService;
        public BuyTicketCommand(TicketService ticketService, InfoService infoService)
        {
            this.ticketService = ticketService;
            this.infoService = infoService;
        }

        public void Execute(string[] data)
        {
            int customerId = 0;

            if (!int.TryParse(data[0], out customerId))
            {
                throw new ArgumentException($"{data[0]} is not a valid input for customer Id!");
            }

            int tripId = 0;

            if (!int.TryParse(data[1], out tripId))
            {
                throw new ArgumentException($"{data[1]} is not a valid input for trip Id!");
            }

            decimal price = 0;

            if (!decimal.TryParse(data[2], out price) || price < 0)
            {
                throw new ArgumentException($"{data[2]} is not a valid input for price!");
            }

            string seatNumber = data[3];

            if (!infoService.CustomerExists(customerId))
            {
                throw new ArgumentException("No such customer found!");
            }

            if (!infoService.TripExists(tripId))
            {
                throw new ArgumentException("No such trip found!");
            }

            if (!infoService.CustomerHasEnoughMoney(customerId, price))
            {
                throw new ArgumentException("Customer bank balance is not enough to purchase a ticket!");
            }

            ticketService.Buy(customerId, tripId, price, seatNumber);
        }
    }
}
