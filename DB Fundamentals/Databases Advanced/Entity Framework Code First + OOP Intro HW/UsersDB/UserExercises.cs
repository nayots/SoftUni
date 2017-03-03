using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UsersDB.Models;
using System.Globalization;

namespace UsersDB
{
    class UserExercises
    {
        static void Main(string[] args)
        {
            //var context = new UsersContext();

            //context.Database.Initialize(true);

            //Use this if you want to add a test user
            //AddTestUsers();

            //11.	Get Users by Email Provider
            //GetUsersByEmail();

            //12.	Remove Inactive Users
            //RemoveInactiveUsers();


        }

        private static void RemoveInactiveUsers()
        {

            DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "dd MMM yyyy", CultureInfo.InvariantCulture);

            var context = new UsersContext();

            var users = context.Users
                .Where(x => x.LastTimeLoggedIn < inputDate)
                .ToList();

            users.ForEach(z => z.IsDeleted = true);

            context.Users.RemoveRange(users);

            context.SaveChanges();

            if (users.Count > 0)
            {
                Console.WriteLine($"{users.Count} users have been deleted");
            }
            else
            {
                Console.WriteLine("No users have been deleted");
            }
        }

        private static void GetUsersByEmail()
        {
            Console.Write("Enter email service provier address:");
            string provider = Console.ReadLine();

            var context = new UsersContext();

            var users = context.Users
                .Where(e => e.Email.Substring((e.Email.Length - provider.Length)) == provider)
                .Select(x => new { Username = x.Username, Email = x.Email })
                .ToList();

            foreach (var us in users)
            {
                Console.WriteLine($"{us.Username} {us.Email}");
            }
            if (users.Count < 1)
            {
                Console.WriteLine($"No users with provider *{provider}*");
            }
        }

        private static void AddTestUsers()
        {
            User testUserOne = new User
            {
                Username = "GOOOOOSHO",
                Password = "@iW24W",
                Email = "gosho@sasho.com",
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = new DateTime(2016, 10, 25),
                Age = 100,
                IsDeleted = false
            };

            //TestUserTwo wont pass the validation and the program will throw an exception!
            //
            //User testUserTwo = new User
            //{
            //    Username = "sho",
            //    Password = "123",
            //    Email = "gosho.@sasho.com",
            //    RegisteredOn = DateTime.Now,
            //    LastTimeLoggedIn = new DateTime(2016, 10, 25),
            //    Age = 1000,
            //    IsDeleted = false
            //};

            var context = new UsersContext();

            context.Users.Add(testUserOne);
            //context.Users.Add(testUserTwo);
            context.SaveChanges();
        }
    }
}
