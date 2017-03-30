using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class LogoutCommand
    {
        private readonly UserService userService;

        public LogoutCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 0)
            {
                throw new FormatException("Invalid arguments count!");
            }

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            User user = AuthenticationService.GetCurrentUser();

            AuthenticationService.Logout();

            string result = $"User {user.Username} successfully logged out!";
            return result;
        }
    }
}
