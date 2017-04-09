using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Discovery
    {
        public Discovery()
        {
            this.Stars = new List<Star>();
            this.Planets = new List<Planet>();
            this.Pioneers = new List<Astronomer>();
            this.Observers = new List<Astronomer>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("TelescopeUsed")]
        public int TelescopeUsedId { get; set; }

        [Required]
        public virtual Telescope TelescopeUsed { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Astronomer> Pioneers { get; set; }

        public virtual ICollection<Astronomer> Observers { get; set; }
    }
}
