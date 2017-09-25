using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BackgroundColour { get; set; }

        public bool IsPublic { get; set; }

        public ICollection<AlbumPicture> Pictures { get; set; } = new List<AlbumPicture>();

        public ICollection<UserAlbum> AlbumHolders { get; set; } = new List<UserAlbum>();

        public ICollection<AlbumTag> Tags { get; set; } = new List<AlbumTag>();
    }
}