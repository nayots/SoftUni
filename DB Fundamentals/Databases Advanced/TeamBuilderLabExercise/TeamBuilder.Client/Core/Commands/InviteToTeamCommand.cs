using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class InviteToTeamCommand
    {
        private readonly TeamService teamService;
        private readonly UserService userService;
        public InviteToTeamCommand(TeamService teamService, UserService userService)
        {
            this.teamService = teamService;
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 2)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string teamName = data[0];
            string username = data[1];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            if (!userService.UsernameExists(username) || !teamService.TeamExists(teamName))
            {
                throw new ArgumentException("Team or user does not exist!");
            }

            User invitedUser = userService.GetUser(username);

            if (teamService.InviteExists(teamName, invitedUser))
            {
                throw new InvalidOperationException("Invite already sent!");
            }

            string currentUserUsername = AuthenticationService.GetCurrentUser().Username;

            string teamCreatorUsername = teamService.GetCreatorUsername(teamName);

            if (currentUserUsername != teamCreatorUsername)
            {
                throw new InvalidOperationException("Not allowed!");
            }

            if (currentUserUsername == username)
            {
                teamService.AddToTeam(teamName, username);
            }
            else
            {
                teamService.SendInvite(teamName, username);
            }

            string result = $"Team {teamName} invited {username}!";
            return result;
        }
    }
}
