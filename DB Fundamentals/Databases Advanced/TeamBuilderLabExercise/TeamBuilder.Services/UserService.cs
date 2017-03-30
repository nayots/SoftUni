using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.Services
{
    public class UserService
    {
        public bool UsernameExists(string username)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public void RegisterUser(string username, string password, string firstName, string lastName, int age, Gender gender)
        {
            using (var context = new TeamBuilderContext())
            {
                User user = new User
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };

                context.Users.Add(user);

                context.SaveChanges();
            }
        }

        public int ImportUsers(string filePath)
        {
            XDocument usersXml = XDocument.Load(filePath);

            var users = new List<User>();

            foreach (var user in usersXml.Root.Elements())
            {
                string username = null;
                string password = null;
                string firstName = null;
                string lastName = null;
                int age = 0;
                Gender gender = Gender.Male;

                var usernameEle = user.Element("username");

                if (usernameEle != null)
                {
                    username = user.Element("username").Value;
                }

                var passwordEle = user.Element("password");

                if (passwordEle != null)
                {
                    password = user.Element("password").Value;
                }

                var firstNameEle = user.Element("first-name");

                if (firstNameEle != null)
                {
                    firstName = user.Element("first-name").Value;
                }

                var lastNameEle = user.Element("last-name");

                if (lastNameEle != null)
                {
                    lastName = user.Element("last-name").Value;
                }

                var ageEle = user.Element("age");

                if (ageEle != null)
                {
                    int.TryParse(user.Element("age").Value, out age);
                }

                var genderEle = user.Element("gender");

                if (genderEle != null)
                {
                    if (user.Element("gender").Value.Length >= 4)
                    {
                        string genderStr = user.Element("gender").Value.Substring(0, 1).ToUpper() + user.Element("gender").Value.Substring(1);

                        Enum.TryParse(genderStr, out gender);

                    }
                }

                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender =gender
                };

                users.Add(newUser);
            }

            var userCount = users.Count();

            using (var context = new TeamBuilderContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return userCount;
        }

        public void DeleteUser(string username)
        {
            using (var context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);

                user.IsDeleted = true;

                context.SaveChanges();
            }
        }

        public void DeclineInvite(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                string currentUserUsername = AuthenticationService.GetCurrentUser().Username;

                User user = context.Users.FirstOrDefault(u => u.Username == currentUserUsername);

                Invitation invite = user
                    .ReceivedInvitations
                    .FirstOrDefault(i => i.Team.Name == teamName && i.IsActive == true);

                invite.IsActive = false;

                context.SaveChanges();
            }
        }

        public void AcceptInvite(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                string currentUserUsername = AuthenticationService.GetCurrentUser().Username;

                User user = context.Users.FirstOrDefault(u => u.Username == currentUserUsername);

                Invitation invite = user
                    .ReceivedInvitations
                    .FirstOrDefault(i => i.Team.Name == teamName && i.IsActive == true);

                Team invitingTeam = invite.Team;

                invite.IsActive = false;

                invitingTeam.Members.Add(user);

                context.SaveChanges();
            }
        }

        public User GetUser(string username)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username);
            }
        }
    }
}
