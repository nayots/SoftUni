namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;

    public class PrintFriendsListCommand 
    {
        private readonly UserService userService;
        public PrintFriendsListCommand(UserService userService)
        {
            this.userService = userService;
        }
        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            string username = data[0];
            string result = string.Empty;

            if (!userService.UserExists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (userService.UserHasFriends(username))
            {
                result = userService.ListFriends(username);
            }
            else
            {
                result = "No friends for this user. :(";
            }

            return result;
        }
    }
}
