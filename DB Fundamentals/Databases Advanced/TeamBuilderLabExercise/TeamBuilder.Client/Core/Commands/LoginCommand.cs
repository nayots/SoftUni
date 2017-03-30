using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class LoginCommand
    {
        private readonly UserService userService;
        public LoginCommand(UserService userService)
        {
            this.userService = userService;
        }
        public string Execute(string[] data)
        {
            if (data.Count() != 2)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string username = data[0];
            string password = data[1];

            if (!userService.UsernameExists(username))
            {
                throw new ArgumentException("Invalid username or password!");
            }

            User user = userService.GetUser(username);

            if (user.Password != password || user.IsDeleted == true)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            if (AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            AuthenticationService.Login(username, password);

            string result = $"User {username} successfully logged in!";

            return result;
        }
    }
}
