namespace AutoMappingProjection
{
    using AutoMappingProjection.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AMProjectionContext : DbContext
    {
        // Your context has been configured to use a 'AMProjectionContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AutoMappingProjection.AMProjectionContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AMProjectionContext' 
        // connection string in the application configuration file.
        public AMProjectionContext()
            : base("name=AMProjectionContext")
        {
            Database.SetInitializer(new DBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.ManagerId);

            base.OnModelCreating(modelBuilder);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}