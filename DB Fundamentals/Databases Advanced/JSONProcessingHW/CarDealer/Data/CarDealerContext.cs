namespace CarDealer.Data
{
    using CarDealer.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarDealerContext : DbContext
    {
        // Your context has been configured to use a 'CarDealerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CarDealer.Data.CarDealerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CarDealerContext' 
        // connection string in the application configuration file.
        public CarDealerContext()
            : base("name=CarDealerContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CarDealerContext>());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}