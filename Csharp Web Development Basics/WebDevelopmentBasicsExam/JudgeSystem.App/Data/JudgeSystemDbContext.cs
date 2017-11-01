using JudgeSystem.App.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Data
{
    public class JudgeSystemDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Contest> Contests { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=JudgeSystem112489STG;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>()
                .HasMany(u => u.Submissions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            builder.Entity<UserContest>()
                .HasKey(uc => new { uc.UserId, uc.ContestId });

            builder.Entity<User>()
                .HasMany(u => u.Contests)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserId);

            builder.Entity<Contest>()
                .HasMany(c => c.Participants)
                .WithOne(uc => uc.Contest)
                .HasForeignKey(uc => uc.ContestId);

            builder.Entity<Contest>()
                .HasMany(c => c.Submissions)
                .WithOne(s => s.Contest)
                .HasForeignKey(s => s.ContestId);
        }
    }
}