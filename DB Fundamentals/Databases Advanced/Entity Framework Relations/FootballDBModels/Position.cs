using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class Position
    {
        public Position()
        {
            this.Players = new List<Player>();
        }

        [Key]
        [MinLength(2)]
        [MaxLength(2)]
        public string Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
