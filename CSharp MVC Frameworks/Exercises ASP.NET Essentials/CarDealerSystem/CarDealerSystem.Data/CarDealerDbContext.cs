using CarDealerSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealerSystem.Web.Data
{
    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LogEntry> Logs { get; set; }

        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartCar>().HasKey(pc => new { pc.PartId, pc.CarId });

            builder.Entity<Car>()
                .HasMany(c => c.Parts)
                .WithOne(pc => pc.Car)
                .HasForeignKey(pc => pc.CarId);

            builder.Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(pc => pc.Part)
                .HasForeignKey(pc => pc.PartId);

            builder.Entity<Part>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Parts)
                .HasForeignKey(p => p.SupplierId);

            builder.Entity<Car>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Car)
                .HasForeignKey(s => s.CarId);

            builder.Entity<Customer>()
                .HasMany(u => u.Purchases)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);

            base.OnModelCreating(builder);
        }
    }
}