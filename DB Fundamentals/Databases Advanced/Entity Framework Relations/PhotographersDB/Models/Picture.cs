using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographersDB.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Albums = new List<Album>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string FilePath { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
