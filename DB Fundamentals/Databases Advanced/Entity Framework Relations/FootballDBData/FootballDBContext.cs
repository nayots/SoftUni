namespace FootballDBData
{
    using FootballDBModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FootballDBContext : DbContext
    {
        public FootballDBContext()
            : base("name=FootballDBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FootballDBContext>());
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<BetGame> BetGames { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Competition> Competition { get; set; }
        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ResultPrediction> ResultPredictions { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}