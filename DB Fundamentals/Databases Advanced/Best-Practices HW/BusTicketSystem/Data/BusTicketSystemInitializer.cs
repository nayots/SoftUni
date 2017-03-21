using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace Data
{
    public class BusTicketSystemInitializer : DropCreateDatabaseAlways<BusTicketSystemContext>
    {
        protected override void Seed(BusTicketSystemContext context)
        {
            Country country1 = new Country();

            country1.Name = "Bulgaria";

            context.Countries.Add(country1);

            Town town1 = new Town
            {
                Country = country1,
                Name = "Sofia"
            };

            Town town2 = new Town
            {
                Country = country1,
                Name = "Plovdiv"
            };

            Town town3 = new Town
            {
                Country = country1,
                Name = "Varna"
            };

            context.Towns.Add(town1);
            context.Towns.Add(town2);
            context.Towns.Add(town3);

            Customer customer1 = new Customer
            {
                FirstName = "Georgi",
                LastName = "Ivanov",
                DateOfBirth = new DateTime(1980, 11, 01),
                Gender = Gender.male,
                HomeTown = town1
            };

            Customer customer2 = new Customer
            {
                FirstName = "Petar",
                LastName = "Georgiev",
                DateOfBirth = new DateTime(1980, 01, 01),
                Gender = Gender.male,
                HomeTown = town2
            };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);

            BankAccount bankAc1 = new BankAccount
            {
                AccountHolder = customer1,
                AccountNumber = "ACN1",
                Balance = 10000M
            };

            BankAccount bankAc2 = new BankAccount
            {
                AccountHolder = customer2,
                AccountNumber = "ACN2",
                Balance = 5050.30M
            };

            context.BankAccounts.Add(bankAc1);
            context.BankAccounts.Add(bankAc2);

            BusCompany busC1 = new BusCompany
            {
                Name = "SpeedExpress",
                Nationality = "Bulgarian",
                Rating = 10
            };

            BusCompany busC2 = new BusCompany
            {
                Name = "MegaSpeed",
                Nationality = "Bulgarian",
                Rating = 9.9
            };

            context.BusCompanies.Add(busC1);
            context.BusCompanies.Add(busC2);

            BusStation busS1 = new BusStation
            {
                Name = "Classic Station",
                Town = town1
            };

            BusStation busS2 = new BusStation
            {
                Name = "Old Station",
                Town = town2
            };

            BusStation busS3 = new BusStation
            {
                Name = "Sea Station",
                Town = town3
            };

            context.BusStations.Add(busS1);
            context.BusStations.Add(busS2);
            context.BusStations.Add(busS3);

            Review rev1 = new Review
            {
                BusCompany = busC1,
                Customer = customer1,
                Content = "Blabla review",
                Grade = 5.5,
                PublishDate = DateTime.Now
            };

            context.Reviews.Add(rev1);

            Trip trip1 = new Trip
            {
                BusCompany = busC1,
                DepartureTime = new DateTime(2017, 04, 01),
                ArrivalTime = new DateTime(2017, 04, 02),
                DestinationStation = busS2,
                OriginStation = busS1,
                Status = Status.departed
            };

            Trip trip2 = new Trip
            {
                BusCompany = busC2,
                DepartureTime = new DateTime(2017, 03, 01),
                ArrivalTime = new DateTime(2017, 03, 02),
                DestinationStation = busS1,
                OriginStation = busS2,
                Status = Status.departed
            };

            Trip trip3 = new Trip
            {
                BusCompany = busC2,
                DepartureTime = new DateTime(2017, 01, 01),
                ArrivalTime = new DateTime(2017, 01, 02),
                DestinationStation = busS1,
                OriginStation = busS3,
                Status = Status.delayed
            };

            context.Trips.Add(trip1);
            context.Trips.Add(trip2);
            context.Trips.Add(trip3);


            context.SaveChanges();
            base.Seed(context);
        }
    }
}
