using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Astronomer
    {
        public Astronomer()
        {
            this.DiscoveriesMade = new List<Discovery>();
            this.DiscoveriesObserving = new List<Discovery>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

        public virtual ICollection<Discovery> DiscoveriesMade { get; set; }

        public virtual ICollection<Discovery> DiscoveriesObserving { get; set; }
    }
}
