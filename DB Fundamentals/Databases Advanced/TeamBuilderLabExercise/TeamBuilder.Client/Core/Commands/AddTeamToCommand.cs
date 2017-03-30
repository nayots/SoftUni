using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class AddTeamToCommand
    {
        private readonly EventService eventService;
        private readonly TeamService teamService;
        public AddTeamToCommand(EventService eventService, TeamService teamService)
        {
            this.eventService = eventService;
            this.teamService = teamService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 2)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string eventName = data[0];
            string teamName = data[1];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            if (!eventService.EventExists(eventName))
            {
                throw new ArgumentException($"Event {eventName} not found!");
            }

            if (!teamService.TeamExists(teamName))
            {
                throw new ArgumentException($"Team {teamName} not found!");
            }

            int eventId = eventService.GetEventId(eventName);

            string currentUserUsername = AuthenticationService.GetCurrentUser().Username;
            string eventCreatorusername = eventService.GetCreatorUsername(eventId);

            if (currentUserUsername != eventCreatorusername)
            {
                throw new InvalidOperationException("Not allowed!");
            }

            if (eventService.TeamIsParticipating(eventId, teamName))
            {
                throw new InvalidOperationException("Cannot add same team twice!");
            }

            eventService.AddTeamToEvent(eventId, teamName);


            string result = $"Team {teamName} added for {eventName}!";
            return result;
        }
    }
}
