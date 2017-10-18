using System;
using System.Collections.Generic;

namespace MiniServer.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password, DateTime registrationDate)
        {
            this.Username = username;
            this.Password = password;
            this.RegistrationDate = registrationDate;
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}