using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Data
{
    public class BankSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SavingAccount> SavingAccounts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BankSysDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.SavingsAccounts)
                .WithOne(sa => sa.User)
                .HasForeignKey(sa => sa.UserId);

            builder.Entity<User>()
                .HasMany(u => u.CheckingAccounts)
                .WithOne(sa => sa.User)
                .HasForeignKey(sa => sa.UserId);
        }
    }
}