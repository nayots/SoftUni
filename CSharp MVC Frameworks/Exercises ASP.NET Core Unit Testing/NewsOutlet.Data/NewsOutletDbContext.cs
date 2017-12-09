using Microsoft.EntityFrameworkCore;
using NewsOutlet.Data.Models;

namespace NewsOutlet.Data
{
    public class NewsOutletDbContext : DbContext
    {
        public NewsOutletDbContext(DbContextOptions<NewsOutletDbContext> dbContextOptions) : base(dbContextOptions)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<News> News { get; set; }
    }
}