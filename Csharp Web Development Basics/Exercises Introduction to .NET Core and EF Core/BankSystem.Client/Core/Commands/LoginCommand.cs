using BankSystem.Data;
using System.Linq;

namespace BankSystem.Client.Core.Commands
{
    public class LoginCommand : Command
    {
        public LoginCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            if (Engine.UserIsLogged)
            {
                result = string.Format(ErrorMessages.UserIsLogged, "register a user");

                return result;
            }

            if (this.arguments.Length != 2)
            {
                result = ErrorMessages.InvalidArgumentsCount;

                return result;
            }

            string username = this.arguments[0];
            string password = this.arguments[1];

            if (db.Users.Any(u => u.Username == username && u.Password == password))
            {
                var user = db.Users
                    .Where(u => u.Username == username && u.Password == password)
                    .Select(u => new
                    {
                        Id = u.Id,
                        Username = u.Username
                    }).First();

                Engine.CurrentUserId = user.Id;
                Engine.CurrentUserUsername = user.Username;
                Engine.UserIsLogged = true;

                result = string.Format(SuccessMessages.UserLoggedIn, username);
            }
            else
            {
                result = ErrorMessages.IncorrectUsernameOrPassword;
            }

            return result;
        }
    }
}