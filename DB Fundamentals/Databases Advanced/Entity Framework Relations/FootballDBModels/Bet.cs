using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public class Bet
    {
        public Bet()
        {
            this.Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime BetDateTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
