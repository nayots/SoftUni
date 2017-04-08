using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new List<Person>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("OriginPlanet")]
        public int OriginPlanetId { get; set; }

        [Required]
        public virtual Planet OriginPlanet { get; set; }

        [ForeignKey("TeleportPlanet")]
        public int TeleportPlanetId { get; set; }

        [Required]
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }
    }
}
