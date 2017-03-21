using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class AuthenticationService
    {
        private static User loggedUser;

        public static void Login(string username, string password)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                loggedUser = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }

        public static void Logout()
        {
            loggedUser = null;
        }

        public static bool IsAuthenticated()
        {
            return loggedUser != null;
        }

        public static User GetCurrentUser()
        {
            return loggedUser;
        }
    }
}
