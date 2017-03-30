using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class CreateTeamCommand
    {
        private readonly TeamService teamService;
        public CreateTeamCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() < 2 || data.Count() > 3)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string teamName = data[0];
            string acronym = data[1];
            string description = null;

            if (data.Count() == 3)
            {
                description = data[2];
            }

            if (teamService.TeamExists(teamName))
            {
                throw new ArgumentException($"Team {teamName} exists!");
            }

            if (acronym.Length != 3)
            {
                throw new ArgumentException($"Acronym {acronym} not valid!");
            }

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            teamService.Create(teamName, acronym, description);

            string result = $"Team {teamName} successfully created!";
            return result;
        }
    }
}
