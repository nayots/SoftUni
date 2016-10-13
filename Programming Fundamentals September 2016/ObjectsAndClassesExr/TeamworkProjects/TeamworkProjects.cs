using System;
using System.Collections.Generic;
using System.Linq;
//09. TeamworkProjects
namespace TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            teams = FormTeams(teams);
            teams = PopulateTeams(teams);

            List<Team> popTeams = teams.Where(x => x.Members.Count > 0).ToList();
            List<Team> emptyTeams = teams.Where(x => x.Members.Count <= 0).ToList();

            PrintResults(popTeams, emptyTeams);
        }

        private static void PrintResults(List<Team> popTeams, List<Team> emptyTeams)
        {
            foreach (var team in popTeams.OrderByDescending(x => x.Members.Count).ThenBy(z => z.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine($"Teams to disband:");
            foreach (var team in emptyTeams.OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }
        }

        private static List<Team> PopulateTeams(List<Team> teams)
        {
            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string[] demand = command.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string requester = demand[0];
                string teamReq = demand[1];

                bool isExistant = false;
                bool isInTeam = false;

                foreach (var team in teams)
                {
                    if (team.Members.Contains(requester) || team.Creator == requester)
                    {
                        isInTeam = true;
                    }

                }

                foreach (var team in teams)
                {

                    if (team.Name == teamReq)
                    {
                        isExistant = true;
                    }

                    if (isExistant == true && isInTeam == false)
                    {
                        team.Members.Add(requester);
                        break;
                    }
                }
                if (isExistant == false)
                {
                    Console.WriteLine($"Team {teamReq} does not exist!");
                }
                else if (isInTeam == true)
                {
                    Console.WriteLine($"Member {requester} cannot join team {teamReq}!");
                }
                command = Console.ReadLine();
            }
            return teams;
        }

        private static List<Team> FormTeams(List<Team> teams)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split('-');
                string requester = info[0];
                string teamName = info[1];

                bool isAllowed = true;

                
                if (teams.Any(x => x.Name ==teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    isAllowed = false;
                }
                else if (teams.Any(x => x.Creator == requester))
                {
                    Console.WriteLine($"{requester} cannot create another team!");
                    isAllowed = false;
                }

                if (isAllowed)
                {
                    Team team = new Team() { Name = teamName, Creator = requester, Members = new List<string>() };
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {requester}!");
                }
            }
            return teams;
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
