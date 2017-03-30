using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class DisbandCommand
    {
        private readonly TeamService teamService;
        private readonly UserService userService;
        public DisbandCommand(TeamService teamService, UserService userService)
        {
            this.teamService = teamService;
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 1)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string teamName = data[0];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            if (!teamService.TeamExists(teamName))
            {
                throw new ArgumentException($"Team {teamName} not found!");
            }

            string currentUserUsername = AuthenticationService.GetCurrentUser().Username;
            string teamCreatorUsername = teamService.GetCreatorUsername(teamName);

            if (currentUserUsername != teamCreatorUsername)
            {
                throw new InvalidOperationException("Not allowed!");
            }

            teamService.Disband(teamName);

            string result = $"{teamName} has disbanded!";
            return result;
        }
    }
}
