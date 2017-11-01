using FDMC.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class FdmcDbContext : DbContext
    {
        public FdmcDbContext(DbContextOptions<FdmcDbContext> options) : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}