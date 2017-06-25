using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem4_ChampionsLeague
{
    class ChampionsLeague
    {
        private static void Main(string[] args)
        {
            var teams = new List<Team>();

            string pattern = @"^([\w\s]+) \| ([\w\s]+) \| (\d+\:\d+) \| (\d+\:\d+)$";

            Regex rgx = new Regex(pattern);

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var match = rgx.Match(input);

                if (match.Success)
                {
                    //HOME TEAM IS 1st
                    var team1 = match.Groups[1].Value;
                    var team2 = match.Groups[2].Value;
                    int team1Goals = 0;
                    int team2Goals = 0;

                    var gameOneGoals = match.Groups[3].Value.Split(':').Select(int.Parse).ToArray();
                    team1Goals += gameOneGoals[0];
                    team2Goals += gameOneGoals[1];

                    var gameTwoGoals = match.Groups[4].Value.Split(':').Select(int.Parse).ToArray();
                    team1Goals += gameTwoGoals[1];
                    team2Goals += gameTwoGoals[0];

                    if (!teams.Any(x => x.Name == team1))
                    {
                        teams.Add(new Team(team1));
                    }
                    if (!teams.Any(x => x.Name == team2))
                    {
                        teams.Add(new Team(team2));
                    }

                    int team1Index = teams.IndexOf(teams.First(x => x.Name == team1));
                    int team2Index = teams.IndexOf(teams.First(x => x.Name == team2));

                    if (team1Goals == team2Goals)
                    {
                        var team1AwayGoals = gameTwoGoals[1];
                        var team2AwayGoals = gameOneGoals[1];
                        if (team1AwayGoals > team2AwayGoals)
                        {
                            teams[team1Index].Wins++;
                            teams[team1Index].Opponents.Add(team2);
                            teams[team2Index].Opponents.Add(team1);
                        }
                        else
                        {
                            teams[team2Index].Wins++;
                            teams[team2Index].Opponents.Add(team1);
                            teams[team1Index].Opponents.Add(team2);
                        }
                    }
                    else if (team1Goals > team2Goals)
                    {
                        teams[team1Index].Wins++;
                        teams[team1Index].Opponents.Add(team2);
                        teams[team2Index].Opponents.Add(team1);
                    }
                    else
                    {
                        teams[team2Index].Wins++;
                        teams[team2Index].Opponents.Add(team1);
                        teams[team1Index].Opponents.Add(team2);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var t in teams.OrderByDescending(x => x.Wins).ThenBy(n => n.Name))
            {
                Console.WriteLine(t.Name);
                Console.WriteLine($"- Wins: {t.Wins}");

                Console.WriteLine($"- Opponents: {string.Join(", ", t.Opponents.OrderBy(o => o))}");
            }
        }
    }

    class Team
    {
        public Team(string name)
        {
            this.Name = name;
            this.Wins = 0;
            this.Opponents = new HashSet<string>();
        }

        public string Name { get; set; }
        public int Wins { get; set; }
        public ICollection<string> Opponents { get; set; }
    }
}