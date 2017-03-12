using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class BetGame
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Bet")]
        public int BetId { get; set; }
        public virtual Bet Bet { get; set; }


        [ForeignKey("ResultPrediction")]
        public int ResultPredictionId { get; set; }
        public virtual ResultPrediction ResultPrediction { get; set; }
    }
}
