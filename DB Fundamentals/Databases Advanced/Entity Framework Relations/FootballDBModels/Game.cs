using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class Game
    {
        public Game()
        {
            this.Players = new List<Player>();
            this.PlayerStatistics = new List<PlayerStatistic>();
            this.Bets = new List<Bet>();
        }

        [Key]
        public int Id { get; set; }

        //[ForeignKey("HomeTeam")]
        //public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        //[ForeignKey("AwayTeam")]
        //public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime GameDate { get; set; }

        public double HomeTeamWinBetRate { get; set; }

        public double AwayTeamWinBetRate { get; set; }

        public double DrawBetRate { get; set; }

        [ForeignKey("Round")]
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
