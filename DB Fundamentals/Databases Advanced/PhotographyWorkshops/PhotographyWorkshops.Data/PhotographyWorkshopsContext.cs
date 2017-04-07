namespace PhotographyWorkshops.Data
{
    using PhotographyWorkshops.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyWorkshopsContext : DbContext
    {
        // Your context has been configured to use a 'PhotographyWorkshopsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PhotographyWorkshops.Data.PhotographyWorkshopsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotographyWorkshopsContext' 
        // connection string in the application configuration file.
        public PhotographyWorkshopsContext()
            : base("name=PhotographyWorkshopsContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotographyWorkshopsContext>());
        }

        public virtual DbSet<Lens> Lenses { get; set; }
        public virtual DbSet<DSLRCamera> DSLRCameras { get; set; }
        public virtual DbSet<MirrorlessCamera> MirrorlessCameras { get; set; }
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photographer>()
                .HasMany(p => p.WorkshopsAsTrainer)
                .WithRequired(p => p.Trainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasMany(p => p.WorkshopsParticipating)
                .WithMany(p => p.Participants)
                .Map(m => m.ToTable("PhotographerWorkshop").MapLeftKey("PhotographerId").MapRightKey("WorkshopId"));

            modelBuilder.Entity<Photographer>()
                .HasRequired(p => p.PrimaryCamera)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasRequired(p => p.SecondaryCamera)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lens>()
                .HasOptional(l => l.Owner)
                .WithMany(o => o.Lenses)
                .HasForeignKey(l => l.OwnerId);

        }
    }
}