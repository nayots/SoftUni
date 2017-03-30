using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class ShowEventCommand
    {
        private readonly EventService eventService;
        public ShowEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 1)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string eventName = data[0];

            if (!eventService.EventExists(eventName))
            {
                throw new ArgumentException($"Event {eventName} not found!");
            }

            int eventId = eventService.GetEventId(eventName);

            string result = eventService.GetEventInfo(eventId);

            return result;
        }
    }
}
