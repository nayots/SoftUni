using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionType> CompetitionTypes { get; set; }
        public DbSet<BetGame> BetGames { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<ResultPrediction> ResultPredictions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FootballBettingDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>()
                .HasOne(t => t.PrimaryColor)
                .WithMany()
                .HasForeignKey(t => t.PrimaryColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Team>()
                .HasOne(t => t.SecondaryColor)
                .WithMany()
                .HasForeignKey(t => t.SecondaryColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Team>()
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Town>()
            //    .HasMany(t => t.Teams)
            //    .WithOne(t => t.Town)
            //    .HasForeignKey(t => t.TownId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Town>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CountryContinent>()
                .HasKey(cc => new { cc.CountryId, cc.ContinentId });

            builder.Entity<Country>()
                .HasMany(c => c.Continents)
                .WithOne(cc => cc.Country)
                .HasForeignKey(cc => cc.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Continent>()
                .HasMany(c => c.Countries)
                .WithOne(cc => cc.Continent)
                .HasForeignKey(cc => cc.ContinentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PlayerGame>()
                .HasKey(pg => new { pg.PlayerId, pg.GameId });

            builder.Entity<Player>()
                .HasMany(p => p.Games)
                .WithOne(pg => pg.Player)
                .HasForeignKey(pg => pg.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasMany(g => g.Players)
                .WithOne(pg => pg.Game)
                .HasForeignKey(pg => pg.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.GameId, ps.PlayerId });

            builder.Entity<Player>()
                .HasMany(p => p.GamesStatistics)
                .WithOne(ps => ps.Player)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasMany(g => g.PlayersStatistics)
                .WithOne(ps => ps.Game)
                .HasForeignKey(ps => ps.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.GamesAsHosts)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.GamesAsGuests)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasOne(g => g.Round)
                .WithMany(r => r.Games)
                .HasForeignKey(g => g.RoundId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasOne(g => g.Competition)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CompetitionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BetGame>()
                .HasKey(bg => new { bg.BetId, bg.GameId });

            builder.Entity<BetGame>()
                .HasOne(bg => bg.ResultPrediction)
                .WithMany()
                .HasForeignKey(bg => bg.ResultPredictionId);

            builder.Entity<Bet>()
                .HasMany(b => b.Games)
                .WithOne(bg => bg.Bet)
                .HasForeignKey(bg => bg.BetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasMany(g => g.Bets)
                .WithOne(bg => bg.Game)
                .HasForeignKey(bg => bg.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bet>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}