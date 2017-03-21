namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Services;
    using System;

    public class AddTownCommand
    {
        private readonly TownService townService;
        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (this.townService.TownExists(townName))
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }

            this.townService.Add(townName, country);

            return townName + " was added successfully!";
        }
    }
}
