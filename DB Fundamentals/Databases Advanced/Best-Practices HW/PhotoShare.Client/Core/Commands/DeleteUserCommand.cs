namespace PhotoShare.Client.Core.Commands
{
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

            if (!this.userService.UserExists(username))
            {
                throw new InvalidOperationException($"User {username} was not found!");
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
