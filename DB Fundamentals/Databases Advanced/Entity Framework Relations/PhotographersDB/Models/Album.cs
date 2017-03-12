using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographersDB.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new List<Picture>();
            this.Tags = new List<Tag>();
            this.Photographers = new List<PhotographerAlbum>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<PhotographerAlbum> Photographers { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
