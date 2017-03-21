namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class BusTicketSystemContext : DbContext
    {
        // Your context has been configured to use a 'BusTicketSystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.BusTicketSystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BusTicketSystemContext' 
        // connection string in the application configuration file.
        public BusTicketSystemContext()
            : base("name=BusTicketSystemContext")
        {
            Database.SetInitializer(new BusTicketSystemInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Trip>()
        //        .HasRequired(m => m.OriginStation)
        //        .WithMany(m => m.Trips)
        //        .HasForeignKey(m => m.OriginStationId);
        //    modelBuilder.Entity<Trip>()
        //        .HasRequired(m => m.DestinationStation)
        //        .WithMany(m => m.Trips)
        //        .HasForeignKey(m => m.DestinationStationId);

        //    base.OnModelCreating(modelBuilder);
        //}

        public virtual DbSet<BusCompany> BusCompanies { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<BusStation> BusStations { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }

        public virtual DbSet<ArrivedTrip> ArrivedTrips { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}