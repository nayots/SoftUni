using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }//This is a url path

        [MinLength(3)]
        [MaxLength(3)]
        public string Initials { get; set; }

        //[ForeignKey("PrimaryColor")]
        //public int PrimaryColorId { get; set; }
        public virtual Color PrimaryColor { get; set; }

        //[ForeignKey("SecondaryColor")]
        //public int SecondaryColorId { get; set; }

        public virtual Color SecondaryColor { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public decimal Budget { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
