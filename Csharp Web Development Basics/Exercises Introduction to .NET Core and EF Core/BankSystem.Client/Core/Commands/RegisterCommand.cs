using BankSystem.Data;
using BankSystem.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankSystem.Client.Core.Commands
{
    public class RegisterCommand : Command
    {
        private const string UsernamePattern = @"^[a-zA-Z][a-zA-Z0-9]{2,}$";
        private const string PasswordPattern = @"^(?=[^\s]*[a-z])(?=[^\s]*[A-Z])(?=[^\s]*\d)[a-zA-Z0-9]{7,}$";
        private const string EmailPattern = @"^([a-zA-Z0-9]+[.-_]?[a-zA-Z0-9]+)(@)[a-zA-Z0-9]+[-]?[a-zA-Z0-9]+(\.[a-zA-Z0-9]{2,})+$";

        public RegisterCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
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

            if (this.arguments.Length != 3)
            {
                result = ErrorMessages.InvalidArgumentsCount;

                return result;
            }

            string username = arguments[0];
            string password = arguments[1];
            string email = arguments[2];

            if (!Regex.IsMatch(username, UsernamePattern))
            {
                result = ErrorMessages.IncorrectUsername;
                return result;
            }

            if (!Regex.IsMatch(password, PasswordPattern))
            {
                result = ErrorMessages.IncorrectPassword;
                return result;
            }

            if (!Regex.IsMatch(email, EmailPattern))
            {
                result = ErrorMessages.IncorrectEmail;
                return result;
            }

            if (db.Users.Any(u => u.Username == username))
            {
                result = string.Format(ErrorMessages.UserExists, username);

                return result;
            }

            var user = new User(username, password, email);

            db.Users.Add(user);
            db.SaveChanges();

            result = string.Format(SuccessMessages.UserRegistered, username);

            return result;
        }
    }
}