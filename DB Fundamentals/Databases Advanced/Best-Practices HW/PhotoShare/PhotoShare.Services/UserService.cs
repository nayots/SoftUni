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

        public string ListFriends(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var userFriends = context.Users
                    .FirstOrDefault(u => u.Username == username)
                    .Friends
                    .OrderBy(o => o.Username)
                    .Select(x => x.Username)
                    .ToList();


                string result = String.Join("\n", userFriends);

                return result;
            }
        }

        public bool CheckPassword(string username, string password)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UserHasFriends(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                if (user.Friends.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UsersAreFriends(string usernameTwo, string usernameOne)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var friend = context.Users.FirstOrDefault(u => u.Username == usernameTwo);

                var user = context.Users.FirstOrDefault(s => s.Username == usernameOne);

                if (user.Friends.Contains(friend))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void MakeFriends(string usernameTwo, string usernameOne)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var friend = context.Users.FirstOrDefault(u => u.Username == usernameTwo);

                var user = context.Users.FirstOrDefault(s => s.Username == usernameOne);

                user.Friends.Add(friend);

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
