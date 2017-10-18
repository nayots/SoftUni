using System.Collections.Generic;

namespace SimpleMvc.Domain
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Notes = new List<Note>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}