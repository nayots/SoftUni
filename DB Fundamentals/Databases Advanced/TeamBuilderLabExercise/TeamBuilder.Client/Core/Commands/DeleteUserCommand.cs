using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class DeleteUserCommand
    {
        private readonly UserService userService;
        public DeleteUserCommand(UserService userService)
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
                throw new InvalidOperationException($"You should login first!");
            }

            User currentUser = AuthenticationService.GetCurrentUser();

            string username = currentUser.Username;

            userService.DeleteUser(username);

            AuthenticationService.Logout();

            string result = $"User {username} was deleted successfully!";
            return result;
        }
    }
}
