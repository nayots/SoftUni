using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Services
{
    public class TeamService
    {
        public bool TeamExists(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public void Create(string teamName, string acronym, string description)
        {
            using (var context = new TeamBuilderContext())
            {
                string currentUserUsername = AuthenticationService.GetCurrentUser().Username;

                User creator = context.Users.FirstOrDefault(u => u.Username == currentUserUsername);

                Team newTeam = new Team
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    Creator = creator
                };

                context.Teams.Add(newTeam);
                context.SaveChanges();
            }
        }

        public void ExportTeamJson(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams
                    .Include("Members")
                    .FirstOrDefault(t => t.Name == teamName);

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                string json = JsonConvert.SerializeObject(new
                {
                    Name = team.Name,
                    Acronym = team.Acronym,
                    Members = team.Members.Select(m => m.Username)
                }, settings);

                File.WriteAllText("team.json", json);
            }
        }

        public int ImportTeams(string filePath)
        {
            XDocument teamsXml = XDocument.Load(filePath);

            var teams = new List<Team>();

            foreach (var team in teamsXml.Root.Elements())
            {
                string name = null;
                string acronym = null;
                string description = null;
                int creatorId = 0;

                var nameEle = team.Element("name");

                if (nameEle != null)
                {
                    name = team.Element("name").Value;
                }

                var acronymEle = team.Element("acronym");

                if (acronymEle != null)
                {
                    acronym = team.Element("acronym").Value;
                }

                var descriptionEle = team.Element("description");

                if (descriptionEle != null)
                {
                    description = team.Element("description").Value;
                }

                var creatorIdEle = team.Element("creator-id");

                if (creatorIdEle != null)
                {
                    int.TryParse(team.Element("creator-id").Value, out creatorId);
                }

                Team newTeam = new Team
                {
                    Name = name,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                };

                teams.Add(newTeam);
            }

            var teamsCount = teams.Count();

            using (var context = new TeamBuilderContext())
            {
                context.Teams.AddRange(teams);
                context.SaveChanges();
            }

            return teamsCount;
        }

        public string GetTeamInfo(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                StringBuilder info = new StringBuilder();

                info.AppendLine($"{team.Name} {team.Acronym}");
                info.Append("Members:");
                if (team.Members.Count > 0)
                {
                    info.Append("\n");

                    var last = team.Members.Last();

                    foreach (var member in team.Members)
                    {
                        if (member.Equals(last))
                        {
                            info.Append($"--{member.Username}");
                        }
                        else
                        {
                            info.AppendLine($"--{member.Username}");
                        }
                    }
                }


                return info.ToString();
            }
        }

        public bool InviteExists(string teamName, User invitedUser)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUserId == invitedUser.Id && i.IsActive);
            }
        }

        public void Disband(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                context.Teams.Remove(team);
                context.SaveChanges();
            }
        }

        public bool UserIsMember(string username, string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                return team.Members.Any(m => m.Username == username);
            }
        }

        public string GetCreatorUsername(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                return team.Creator.Username;
            }
        }

        public void KickMember(string username, string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                User user = team.Members.FirstOrDefault(m => m.Username == username);

                team.Members.Remove(user);

                context.SaveChanges();
            }
        }

        public void SendInvite(string teamName, string username)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                User user = context.Users.FirstOrDefault(u => u.Username == username);

                Invitation invite = new Invitation
                {
                    InvitedUser = user,
                    Team = team
                };

                context.Invitations.Add(invite);
                context.SaveChanges();
            }
        }

        public void AddToTeam(string teamName, string username)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                User user = context.Users.FirstOrDefault(u => u.Username == username);

                team.Members.Add(user);
                context.SaveChanges();
            }
        }
    }
}
