namespace JudgeSystem.App.Services
{
    using Contracts;
    using JudgeSystem.App.Data;
    using JudgeSystem.App.Data.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly JudgeSystemDbContext db;

        public UserService(JudgeSystemDbContext db)
        {
            this.db = db;
        }

        public bool Create(string email, string password, string fullname)
        {
            if (this.db.Users.Any(u => u.Email == email))
            {
                return false;
            }

            var isAdmin = !db.Users.Any();

            var user = new User
            {
                Email = email,
                FullName = fullname,
                Password = password,
                IsAdmin = isAdmin
            };

            db.Add(user);
            db.SaveChanges();

            return true;
        }

        public User GetUserByEmail(string email)
        {
            return this.db.Users.First(u => u.Email == email);
        }

        public bool UserExists(string email, string password)
            => this.db
                .Users
                .Any(u => u.Email == email && u.Password == password);
    }
}