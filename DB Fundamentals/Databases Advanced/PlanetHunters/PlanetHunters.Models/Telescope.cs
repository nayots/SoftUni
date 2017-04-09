using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Telescope
    {
        private double? mirrorDiameter;

        public Telescope()
        {
            this.Discoveries = new List<Discovery>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        public double? MirrorDiameter
        {
            get
            {
                return this.mirrorDiameter;
            }
            set
            {
                if (value <= 0.00)
                {
                    throw new ArgumentOutOfRangeException("MirrorDiameter must be greather than 0.00");
                }

                this.mirrorDiameter = value;
            }
        }

        public virtual ICollection<Discovery> Discoveries { get; set; }
    }
}
