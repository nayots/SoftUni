using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class UserService
    {
        public void Add(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void DeleteUser(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                user.IsDeleted = true;

                context.SaveChanges();
            }
        }

        public bool IsDeleted(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username && u.IsDeleted == true);
            }
        }

        public bool UserExists(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public void ModifyPassword(string username, string password)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                user.Password = password;

                context.SaveChanges();
            }
        }

        public void ModifyBornTown(string username, string bornTownName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                var town = context.Towns.FirstOrDefault(t => t.Name == bornTownName);

                user.BornTown = town;

                context.SaveChanges();
            }
        }

        public void ModifyCurrentTown(string username, string currentTownName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                var town = context.Towns.FirstOrDefault(t => t.Name == currentTownName);

                user.CurrentTown = town;

                context.SaveChanges();
            }
        }
    }
}
