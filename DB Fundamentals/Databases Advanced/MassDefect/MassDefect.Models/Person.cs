using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Models
{
    public class Person
    {
        public Person()
        {
            this.Anomalies = new List<Anomaly>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("HomePlanet")]
        public int HomePlanetId { get; set; }

        [Required]
        public Planet HomePlanet { get; set; }

        public virtual ICollection<Anomaly> Anomalies { get; set; }
    }
}
