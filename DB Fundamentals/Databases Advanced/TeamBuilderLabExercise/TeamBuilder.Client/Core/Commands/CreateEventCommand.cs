using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class CreateEventCommand
    {
        private readonly EventService eventService;
        public CreateEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 6)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string eventName = data[0];
            string description = data[1];
            string startDateArg = $"{data[2]} {data[3]}";
            string endDateArg = $"{data[4]} {data[5]}";

            DateTime startDate;

            if (!DateTime.TryParseExact(startDateArg, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                throw new ArgumentException($"Please insert the dates in format: [dd/MM/yyyy HH:mm]!");
            }

            DateTime endDate;

            if (!DateTime.TryParseExact(endDateArg, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                throw new ArgumentException($"Please insert the dates in format: [dd/MM/yyyy HH:mm]!");
            }

            if (startDate > endDate)
            {
                throw new ArgumentException("Start date should be before end date.");
            }

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            eventService.Create(eventName, description, startDate, endDate);

            string result = $"Event {eventName} was created successfully!";
            return result;
        }
    }
}
