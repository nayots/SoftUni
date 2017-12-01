using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;

namespace LearningSystem.Web.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });

            builder.Entity<User>()
                .HasMany(u => u.CoursesLearning)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);

            builder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(uc => uc.Course)
                .HasForeignKey(uc => uc.CourseId);

            builder.Entity<User>()
                .HasMany(u => u.Articles)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            builder.Entity<User>()
                .HasMany(u => u.CoursesTrainer)
                .WithOne(c => c.Trainer)
                .HasForeignKey(c => c.TrainerId);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}