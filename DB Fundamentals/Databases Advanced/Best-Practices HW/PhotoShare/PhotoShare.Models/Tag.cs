namespace PhotoShare.Models
{
    using System.Collections.Generic;

    using PhotoShare.Models.Validation;

    public class Tag
    {
        private ICollection<Album> albums;

        public Tag()
        {
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
