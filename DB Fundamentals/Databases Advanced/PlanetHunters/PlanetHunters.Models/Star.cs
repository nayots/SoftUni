using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Star
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(2400, int.MaxValue)]
        public int Temperature { get; set; }

        [ForeignKey("HostStarSystem")]
        public int HostStarSystemId { get; set; }

        [Required]
        public virtual StarSystem HostStarSystem { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}
