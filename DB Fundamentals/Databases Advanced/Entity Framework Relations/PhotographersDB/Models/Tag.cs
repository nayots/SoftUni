using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographersDB.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Albums = new List<Album>();
        }

        [Key]
        public int Id { get; set; }
        [Tag]
        public string Label { get; set; }
        
        public virtual ICollection<Album> Albums { get; set; }
    }
}
