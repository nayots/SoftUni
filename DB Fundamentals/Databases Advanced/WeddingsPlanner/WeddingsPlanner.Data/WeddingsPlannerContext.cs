namespace WeddingsPlanner.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WeddingsPlanner.Models;

    public class WeddingsPlannerContext : DbContext
    {
        // Your context has been configured to use a 'WeddingsPlannerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WeddingsPlanner.Data.WeddingsPlannerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WeddingsPlannerContext' 
        // connection string in the application configuration file.
        public WeddingsPlannerContext()
            : base("name=WeddingsPlannerContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<WeddingsPlannerContext>());
        }

        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Wedding> Weddings { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Present> Presents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invitation>()
                .HasOptional(i => i.Present)
                .WithRequired(p => p.Invitation)
                .Map(m => m.MapKey("InvitationId"));

            modelBuilder.Entity<Wedding>()
                .HasRequired(w => w.Bride)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wedding>()
                .HasRequired(w => w.Bridegroom)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wedding>()
                .HasMany(w => w.Venues)
                .WithMany(v => v.Weddings)
                .Map(m =>
                {
                    m.ToTable("WeddingsVenues");
                    m.MapLeftKey("WeddingId");
                    m.MapRightKey("VenueId");
                });
            
            
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}