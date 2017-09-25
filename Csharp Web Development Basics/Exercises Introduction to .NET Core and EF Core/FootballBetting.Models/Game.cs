using System;
using System.Collections.Generic;

namespace FootballBetting.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime DateOfGame { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawGameBetRate { get; set; }

        public int RoundId { get; set; }

        public Round Round { get; set; }

        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }

        public ICollection<PlayerGame> Players { get; set; } = new List<PlayerGame>();

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new List<PlayerStatistic>();

        public ICollection<BetGame> Bets { get; set; } = new List<BetGame>();
    }
}