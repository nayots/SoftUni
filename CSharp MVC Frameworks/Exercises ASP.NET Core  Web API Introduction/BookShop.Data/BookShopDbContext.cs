using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> dbContextOptions) : base(dbContextOptions)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<CategoryBook>()
                .HasKey(cb => new { cb.CategoryId, cb.BookId });

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(cb => cb.Book)
                .HasForeignKey(cb => cb.BookId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(cb => cb.Category)
                .HasForeignKey(cb => cb.CategoryId);
        }
    }
}