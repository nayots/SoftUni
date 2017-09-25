using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime BetDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<BetGame> Games { get; set; } = new List<BetGame>();
    }
}