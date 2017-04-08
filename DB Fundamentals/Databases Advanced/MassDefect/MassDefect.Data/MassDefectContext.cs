namespace MassDefect.Data
{
    using MassDefect.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectContext>());
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Anomaly> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasMany(a => a.Victims)
                .WithMany(p => p.Anomalies)
                .Map(m =>
                {
                    m.MapLeftKey("AnomalyId");
                    m.MapRightKey("PersonId");
                    m.ToTable("AnomalyVictims");
                });

            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.OriginPlanet)
                .WithMany(p => p.OriginatingAnomalies)
                .HasForeignKey(a => a.OriginPlanetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.TeleportPlanet)
                .WithMany(p => p.TerminatingAnomalies)
                .HasForeignKey(a => a.TeleportPlanetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Star>()
                .HasRequired(s => s.SolarSystem)
                .WithMany(ss => ss.Stars)
                .HasForeignKey(s => s.SolarSystemId)
                .WillCascadeOnDelete(false);
        }
    }

}