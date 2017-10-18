using Microsoft.EntityFrameworkCore;
using SimpleMvc.Domain;

namespace SimpleMvc.Data
{
    public class NotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=NotesDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.Owner)
                .HasForeignKey(n => n.OwnerId);
        }
    }
}