namespace PhotoShare.Models
{
    public class AlbumRole
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual Album Album { get; set; }

        public Role Role { get; set; }

        public override string ToString()
        {
            return $"{this.User.Username} - {this.Album.Name} - {this.Role}";
        }
    }
}
