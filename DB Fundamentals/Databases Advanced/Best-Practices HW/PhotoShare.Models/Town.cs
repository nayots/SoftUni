namespace PhotoShare.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        private ICollection<User> usersBornInTown;
        private ICollection<User> usersCurrentlyLivingInTown;

        public Town()
        {
            this.usersBornInTown = new HashSet<User>();
            this.usersCurrentlyLivingInTown = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        [InverseProperty("BornTown")]
        public ICollection<User> UsersBornInTown
        {
            get { return this.usersBornInTown; }
            set { this.usersBornInTown = value; }
        }

        [InverseProperty("CurrentTown")]
        public ICollection<User> UsersCurrentlyLivingInTown
        {
            get { return this.usersCurrentlyLivingInTown; }
            set { this.usersCurrentlyLivingInTown = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Country}";
        }
    }
}
