using Microsoft.EntityFrameworkCore;
using MiniServer.Models;

namespace MiniServer.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CakeShopDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}