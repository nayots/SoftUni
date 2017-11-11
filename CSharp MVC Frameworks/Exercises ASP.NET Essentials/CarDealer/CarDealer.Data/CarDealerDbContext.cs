namespace CarDealer.Data
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext()
        { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }
}
