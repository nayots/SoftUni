using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Services
{
    public class EventService
    {
        public void Create(string eventName, string description, DateTime startDate, DateTime endDate)
        {
            using (var context = new TeamBuilderContext())
            {
                string currentUserUsername = AuthenticationService.GetCurrentUser().Username;

                User creator = context.Users.FirstOrDefault(u => u.Username == currentUserUsername);

                Event newEvent = new Event
                {
                    Name = eventName,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Creator = creator
                };

                context.Events.Add(newEvent);

                context.SaveChanges();
            }
        }

        public string GetEventInfo(int eventId)
        {
            using (var context = new TeamBuilderContext())
            {
                StringBuilder info = new StringBuilder();

                Event featuredEvent = context.Events.FirstOrDefault(e => e.Id == eventId);



                info.AppendLine($"{featuredEvent.Name} {featuredEvent.StartDate.ToString(@"dd'/'MM'/'yyyy HH:mm") ?? "No start date"} {featuredEvent.EndDate.ToString(@"dd'/'MM'/'yyyy HH:mm") ?? "No end date"}");
                info.AppendLine($"{featuredEvent.Description ?? "No description"}");
                info.Append("Teams:");

                if (featuredEvent.ParticipatingTeams.Count > 0)
                {
                    info.Append("\n");

                    var last = featuredEvent.ParticipatingTeams.Last();

                    foreach (var team in featuredEvent.ParticipatingTeams)
                    {
                        if (team.Equals(last))
                        {
                            info.Append($"-{team.Name}");
                        }
                        else
                        {
                            info.AppendLine($"-{team.Name}");
                        }
                    }
                }


                return info.ToString();
            }
        }

        public bool EventExists(string eventName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.Name == eventName);
            }
        }

        public int GetEventId(string eventName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events
                    .Where(e => e.Name == eventName)
                    .OrderByDescending(e => e.StartDate)
                    .FirstOrDefault()
                    .Id;
            }
        }

        public string GetCreatorUsername(int eventId)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events
                    .FirstOrDefault(e => e.Id == eventId)
                    .Creator
                    .Username;
            }
        }

        public void AddTeamToEvent(int eventId, string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Event featuredEvent = context.Events.FirstOrDefault(e => e.Id == eventId);

                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                featuredEvent.ParticipatingTeams.Add(team);

                context.SaveChanges();
            }
        }

        public bool TeamIsParticipating(int eventId, string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Event featuredEvent = context.Events
                    .FirstOrDefault(e => e.Id == eventId);

                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                return featuredEvent.ParticipatingTeams.Contains(team);
            }
        }
    }
}
