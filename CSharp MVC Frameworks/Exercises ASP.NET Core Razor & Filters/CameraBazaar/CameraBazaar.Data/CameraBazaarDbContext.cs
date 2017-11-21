using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CameraBazaar.Data.Models;

namespace CameraBazaar.Data
{
    public class CameraBazaarDbContext : IdentityDbContext<User>
    {
        public DbSet<Camera> Cameras { get; set; }

        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.Cameras)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}