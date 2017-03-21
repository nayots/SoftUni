namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;

    public class MakeFriendsCommand
    {
        private readonly UserService userService;
        public MakeFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            string usernameOne = data[0];
            string usernameTwo = data[1];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            User currentUser = AuthenticationService.GetCurrentUser();

            if (currentUser.Username != usernameOne)
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            if (!userService.UserExists(usernameOne))
            {
                throw new ArgumentException($"{usernameOne} not found!");
            }
            if (!userService.UserExists(usernameTwo))
            {
                throw new ArgumentException($"{usernameTwo} not found!");
            }

            if (userService.UsersAreFriends(usernameTwo, usernameOne))
            {
                throw new InvalidOperationException($"{usernameTwo} is already a friend to {usernameOne}");
            }

            userService.MakeFriends(usernameTwo, usernameOne);

            return "Friend " + usernameTwo + " added to " + usernameOne;
        }
    }
}
