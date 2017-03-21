namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;
    using System.Linq;

    public class DeleteUserCommand
    {
        private readonly UserService userService;
        public DeleteUserCommand(UserService userService)
        {
            this.userService = userService;
        }
        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            User currentUser = AuthenticationService.GetCurrentUser();


            if (!this.userService.UserExists(username))
            {
                throw new InvalidOperationException($"User {username} was not found!");
            }

            if (currentUser.Username != username)
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            if (this.userService.IsDeleted(username))
            {
                throw new InvalidOperationException($"User {username} is already deleted!");
            }

            this.userService.DeleteUser(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
