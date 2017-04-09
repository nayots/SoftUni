using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Planet
    {
        private double mass;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public double Mass
        {
            get
            {
                return this.mass;
            }
            set
            {
                if (value <= 0.00)
                {
                    throw new ArgumentOutOfRangeException("Mass must be bigger than zero");
                }

                this.mass = value;
            }
        }

        [ForeignKey("HostStarSystem")]
        public int HostStarSystemId { get; set; }

        public virtual StarSystem HostStarSystem { get; set; }

        public virtual Discovery Discovery { get; set; }
    }
}
