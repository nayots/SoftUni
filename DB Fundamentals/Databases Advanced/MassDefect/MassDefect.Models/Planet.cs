using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    public class Planet
    {
        public Planet()
        {
            this.OriginatingAnomalies = new List<Anomaly>();
            this.TerminatingAnomalies = new List<Anomaly>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Sun")]
        public int SunId { get; set; }

        [Required]
        public virtual Star Sun { get; set; }

        [ForeignKey("SolarSystem")]
        public int SolarSystemId { get; set; }

        [Required]
        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Anomaly> OriginatingAnomalies { get; set; }

        public virtual ICollection<Anomaly> TerminatingAnomalies { get; set; }
    }
}
