using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public string FilePath { get; set; }

        public ICollection<AlbumPicture> Albums { get; set; } = new List<AlbumPicture>();
    }
}