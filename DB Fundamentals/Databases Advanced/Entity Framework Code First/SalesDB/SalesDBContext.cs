namespace SalesDB
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesDBContext : DbContext
    {
        // Your context has been configured to use a 'SalesDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SalesDB.SalesDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SalesDBContext' 
        // connection string in the application configuration file.
        public SalesDBContext()
            : base("name=SalesDBContext")
        {
            Database.SetInitializer(new SalesDBInitializer());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
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