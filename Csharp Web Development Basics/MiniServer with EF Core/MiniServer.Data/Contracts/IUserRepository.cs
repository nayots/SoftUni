using MiniServer.Models;
using System;
using System.Collections.Generic;

namespace MiniServer.Data.Contracts
{
    public interface IUserRepository : IDisposable
    {
        ICollection<User> GetAllUsers();

        void AddUser(User user);

        User GetUserById(int id);

        User GetUserByUsername(string username);

        bool UserExists(int id);

        bool UserExists(string username);

        bool ValidateCredentials(string username, string password);

        ICollection<Order> GetUserOrders(int userId);

        void Save();
    }
}