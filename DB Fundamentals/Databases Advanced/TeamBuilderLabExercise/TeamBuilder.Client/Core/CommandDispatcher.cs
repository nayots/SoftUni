using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Client.Core.Commands;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core
{
    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();

            string result = string.Empty;

            switch (commandName)
            {
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand(new UserService());
                    result = registerUser.Execute(commandParameters);
                    break;
                case "Login":
                    LoginCommand loginCommand = new LoginCommand(new UserService());
                    result = loginCommand.Execute(commandParameters);
                    break;
                case "Logout":
                    LogoutCommand logoutCommand = new LogoutCommand(new UserService());
                    result = logoutCommand.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    DeleteUserCommand deleteUser = new DeleteUserCommand(new UserService());
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "CreateEvent":
                    CreateEventCommand createEvent = new CreateEventCommand(new EventService());
                    result = createEvent.Execute(commandParameters);
                    break;
                case "CreateTeam":
                    CreateTeamCommand createTeam = new CreateTeamCommand(new TeamService());
                    result = createTeam.Execute(commandParameters);
                    break;
                case "InviteToTeam":
                    InviteToTeamCommand invToTeam = new InviteToTeamCommand(new TeamService(), new UserService());
                    result = invToTeam.Execute(commandParameters);
                    break;
                case "AcceptInvite":
                    AcceptInviteCommand acceptInvite = new AcceptInviteCommand(new TeamService(), new UserService());
                    result = acceptInvite.Execute(commandParameters);
                    break;
                case "DeclineInvite":
                    DeclineInviteCommand declineInvite = new DeclineInviteCommand(new TeamService(), new UserService());
                    result = declineInvite.Execute(commandParameters);
                    break;
                case "KickMember":
                    KickMemberCommand kickMember = new KickMemberCommand(new TeamService(), new UserService());
                    result = kickMember.Execute(commandParameters);
                    break;
                case "Disband":
                    DisbandCommand disbandTeam = new DisbandCommand(new TeamService(), new UserService());
                    result = disbandTeam.Execute(commandParameters);
                    break;
                case "AddTeamTo":
                    AddTeamToCommand addTeam = new AddTeamToCommand(new EventService(), new TeamService());
                    result = addTeam.Execute(commandParameters);
                    break;
                case "ShowEvent":
                    ShowEventCommand showEvent = new ShowEventCommand(new EventService());
                    result = showEvent.Execute(commandParameters);
                    break;
                case "ShowTeam":
                    ShowTeamCommand showTeam = new ShowTeamCommand(new TeamService());
                    result = showTeam.Execute(commandParameters);
                    break;
                case "ImportUsers":
                    ImportUsersCommand importUsers = new ImportUsersCommand(new UserService());
                    result = importUsers.Execute(commandParameters);
                    break;
                case "ImportTeams":
                    ImportTeamsCommand importTeams = new ImportTeamsCommand(new TeamService());
                    result = importTeams.Execute(commandParameters);
                    break;
                case "ExportTeam":
                    ExportTeamCommand exportTeam = new ExportTeamCommand(new TeamService());
                    result = exportTeam.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute(commandParameters);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not valid!");
            }

            return result;
        }
    }
}
