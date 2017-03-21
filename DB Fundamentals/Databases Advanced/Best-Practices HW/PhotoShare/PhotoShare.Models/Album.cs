namespace PhotoShare.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        private ICollection<Picture> pictures;
        private ICollection<Tag> tags;
        private ICollection<AlbumRole> albumRoles;

        public Album()
        {
            this.pictures = new HashSet<Picture>();
            this.tags = new HashSet<Tag>();
            this.albumRoles = new HashSet<AlbumRole>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Color? BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<AlbumRole> AlbumRoles
        {
            get { return this.albumRoles; }
            set { this.albumRoles = value; }
        }

        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} has {this.Pictures.Count} pictures";
        }
    }
}
