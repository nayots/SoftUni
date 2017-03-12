using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class Country
    {
        public Country()
        {
            this.Towns = new List<Town>();
            this.Continents = new List<Continent>();
        }
        [Key]
        [MinLength(3)]
        [MaxLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        //[ForeignKey("Continent")]
        //public int ContientId { get; set; }
        public virtual ICollection<Continent> Continents { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
