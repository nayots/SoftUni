namespace PlanetHunters.Data
{
    using PlanetHunters.Data.Migrations;
    using PlanetHunters.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHuntersContext : DbContext
    {
        // Your context has been configured to use a 'PlanetHuntersContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PlanetHunters.Data.PlanetHuntersContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PlanetHuntersContext' 
        // connection string in the application configuration file.
        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
            //To use the export functionality leave this commented.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PlanetHuntersContext, Configuration>());
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Pioneers)
                .WithMany(a => a.DiscoveriesMade)
                .Map(pd => 
                {
                    pd.MapLeftKey("DiscoveryId"); 
                    pd.MapRightKey("PioneerId");
                    pd.ToTable("DiscoveriesPioneers");
                });

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Observers)
                .WithMany(a => a.DiscoveriesObserving)
                .Map(od =>
                {
                    od.MapLeftKey("DiscoveryId");
                    od.MapRightKey("ObserverId");
                    od.ToTable("DiscoveriesObservers");
                });
        }
    }
}