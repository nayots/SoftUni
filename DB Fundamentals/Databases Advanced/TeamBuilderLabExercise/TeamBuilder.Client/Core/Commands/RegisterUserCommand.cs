using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class RegisterUserCommand
    {
        private readonly UserService userService;

        public RegisterUserCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            if (data.Count() != 7)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string firstName = data[3];
            string lastName = data[4];



            if (username.Length < 3 || username.Length > 25)
            {
                throw new ArgumentException($"Username {username} not valid!");
            }
            if (userService.UsernameExists(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z0-9]{6,30}$"))
            {
                throw new ArgumentException($"Password {password} is not valid!");
            }
            if (password != repeatPassword)
            {
                throw new InvalidOperationException($"Passwords do not match!");
            }
            int age = -1;

            if (!int.TryParse(data[5], out age))
            {
                throw new ArgumentException("Age not valid!");
            }
            if (age < 0)
            {
                throw new ArgumentException("Age not valid!");
            }
            Gender gender = new Gender();

            if (!Enum.TryParse(data[6], out gender))
            {
                throw new ArgumentException("Gender should be either \"Male\" or \"Female\"!");
            }

            if (AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            userService.RegisterUser(username, password, firstName, lastName, age, gender);

            string result = string.Empty;
            result = $"User {username} was registered successfully!";
            return result;

            //RegisterUser gosho 123WwW 123WwW Georgi Ivanov 18 Male
        }
    }
}
