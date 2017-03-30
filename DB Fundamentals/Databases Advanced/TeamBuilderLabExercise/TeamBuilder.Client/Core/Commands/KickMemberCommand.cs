using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class KickMemberCommand
    {
        private readonly TeamService teamService;
        private readonly UserService userService;
        public KickMemberCommand(TeamService teamService, UserService userService)
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

            if (!teamService.TeamExists(teamName))
            {
                throw new ArgumentException($"Team {teamName} not found!");
            }

            if (!userService.UsernameExists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!teamService.UserIsMember(username, teamName))
            {
                throw new ArgumentException($"User {username} is not a member in {teamName}!");
            }

            string currentUserUsername = AuthenticationService.GetCurrentUser().Username;
            string teamCreatorUsername = teamService.GetCreatorUsername(teamName);

            if (teamCreatorUsername != currentUserUsername)
            {
                throw new InvalidOperationException("Not allowed!");
            }

            if (username == teamCreatorUsername)
            {
                throw new InvalidOperationException("Command not allowed. Use DisbandTeam instead.");
            }

            teamService.KickMember(username, teamName);

            string result = $"User {username} was kicked from {teamName}!";
            return result;
        }
    }
}
