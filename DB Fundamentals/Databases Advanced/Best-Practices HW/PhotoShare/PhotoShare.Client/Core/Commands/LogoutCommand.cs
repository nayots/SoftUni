using PhotoShare.Models;
using PhotoShare.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand
    {
        private readonly AuthenticationService authenticationService;
        private readonly UserService userService;
        public LogoutCommand(AuthenticationService authenticationService, UserService userService)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
        }
        public string Execute()
        {
            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            User user = AuthenticationService.GetCurrentUser();

            AuthenticationService.Logout();

            return "User " + user.Username + " successfully logged out!";
        }
    }
}
