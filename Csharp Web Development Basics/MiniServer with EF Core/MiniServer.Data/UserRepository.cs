using Microsoft.EntityFrameworkCore;
using MiniServer.Data.Contracts;
using MiniServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniServer.Data
{
    public class UserRepository : IUserRepository
    {
        private bool disposed = false;
        private ShopDbContext context;

        public UserRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public ICollection<User> GetAllUsers()
        {
            var users = context.Users.ToList();

            return users;
        }

        public User GetUserById(int id)
        {
            var user = context.Users.Include(u => u.Orders).FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = context.Users.Include(u => u.Orders).FirstOrDefault(u => u.Username == username);

            return user;
        }

        public ICollection<Order> GetUserOrders(int userId)
        {
            var orders = context.Users.First(u => u.Id == userId).Orders;

            foreach (var order in orders)
            {
                context.Entry(order).Collection(o => o.Products).Load();
                foreach (var product in order.Products)
                {
                    context.Entry(product).Reference(op => op.Product).Load();
                }
            }

            return orders;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool UserExists(int id)
        {
            bool result = context.Users.Any(u => u.Id == id);

            return result;
        }

        public bool UserExists(string username)
        {
            bool result = context.Users.Any(u => u.Username.ToLower() == username.ToLower());

            return result;
        }

        public bool ValidateCredentials(string username, string password)
        {
            bool userIsValid = context.Users.Any(u => u.Username.ToLower() == username.ToLower() && u.Password == password);

            return userIsValid;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}