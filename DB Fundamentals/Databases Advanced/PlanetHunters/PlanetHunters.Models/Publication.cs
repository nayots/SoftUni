using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Publication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("Discovery")]
        public int DiscoveryId { get; set; }

        [Required]
        public virtual Discovery Discovery { get; set; }
    }
}
