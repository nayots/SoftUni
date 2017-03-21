namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;
    using System.Text.RegularExpressions;

    public class ModifyUserCommand
    {
        private readonly UserService userService;
        private readonly TownService townService;

        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string value = data[2];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            User currentUser = AuthenticationService.GetCurrentUser();

            if (currentUser.Username != username)
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            if (!this.userService.UserExists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }


            if (property == "Password")
            {
                string pattern = @"^.*(?=.{6,50})(?=.*[a-z])(?=.*[0-9]).*$";
                if (Regex.IsMatch(value, pattern))
                {
                    this.userService.ModifyPassword(username, value);
                }
                else
                {
                    Console.WriteLine($"Value {value} is not valid.");
                    throw new ArgumentException("Invalid Password");
                }
            }
            else if (property == "BornTown")
            {
                if (this.townService.TownExists(value))
                {
                    this.userService.ModifyBornTown(username, value);
                }
                else
                {
                    Console.WriteLine($"Value {value} is not valid.");
                    throw new ArgumentException($"Town {value} not found!");
                }
            }
            else if (property == "CurrentTown")
            {
                if (this.townService.TownExists(value))
                {
                    this.userService.ModifyCurrentTown(username, value);
                }
                else
                {
                    Console.WriteLine($"Value {value} is not valid.");
                    throw new ArgumentException($"Town {value} not found!");
                }
            }
            else
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            return "User " + username + " " + property + " is " + value;
        }
    }
}
