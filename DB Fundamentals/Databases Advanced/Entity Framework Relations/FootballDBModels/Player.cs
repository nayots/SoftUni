using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class Player
    {
        public Player()
        {
            this.Games = new List<Game>();
            this.PlayerStatistics = new List<PlayerStatistic>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey("Position")]
        public string PositionId { get; set; }
        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
