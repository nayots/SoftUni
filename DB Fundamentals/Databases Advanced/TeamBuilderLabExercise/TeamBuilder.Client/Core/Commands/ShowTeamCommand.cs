using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class ShowTeamCommand
    {
        private readonly TeamService teamService;
        public ShowTeamCommand(TeamService teamService)
        {
            this.teamService = teamService;
        }
        
        public string Execute(string[] data)
        {
            if (data.Count() != 1)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string teamName = data[0];

            if (!teamService.TeamExists(teamName))
            {
                throw new ArgumentException($"Team {teamName} not found!");
            }

            string result = teamService.GetTeamInfo(teamName);
            return result;
        }
    }
}
