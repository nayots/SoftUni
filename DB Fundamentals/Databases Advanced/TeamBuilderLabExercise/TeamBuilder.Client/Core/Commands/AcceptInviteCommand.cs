using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class AcceptInviteCommand
    {
        private readonly TeamService teamService;
        private readonly UserService userService;
        public AcceptInviteCommand(TeamService teamService, UserService userService)
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

            User currentUser = AuthenticationService.GetCurrentUser();

            if (!teamService.InviteExists(teamName,currentUser))
            {
                throw new ArgumentException($"Invite from {teamName} is not found!");
            }

            userService.AcceptInvite(teamName);


            string currentUserUsername = AuthenticationService.GetCurrentUser().Username;

            string result = $"User {currentUserUsername} joined team {teamName}!";
            return result;
        }
    }
}
