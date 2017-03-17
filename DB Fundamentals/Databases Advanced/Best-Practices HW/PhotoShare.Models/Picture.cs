namespace PhotoShare.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        private ICollection<Album> albums;

        public Picture()
        {
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }

        public override string ToString()
        {
            return $"{this.Title} {this.Caption??string.Empty}";
        }
    }
}
