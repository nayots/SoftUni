using PhotoShare.Models;
using PhotoShare.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginCommand
    {
        private readonly AuthenticationService authenticationService;
        private readonly UserService userService;
        public LoginCommand(AuthenticationService authenticationService, UserService userService)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
        }
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];

            if (!userService.UserExists(username))
            {
                throw new ArgumentException($"Invalid username or password!");
            }
            if (!userService.CheckPassword(username, password))
            {
                throw new ArgumentException($"Invalid username or password!");
            }

            if (AuthenticationService.IsAuthenticated())
            {
                User currentUser = AuthenticationService.GetCurrentUser();

                if (currentUser.Username == username)
                {
                    throw new ArgumentException($"You should logout first!");
                }
                throw new InvalidOperationException("Invalid credentials");
            }


            AuthenticationService.Login(username, password);

            return "User " + username + " successfully logged in!";
        }
    }
}
