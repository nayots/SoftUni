using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SocialNetwork;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>()
                .HasKey(uf => new { uf.FirstUserId, uf.SecondUserId });

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.FirstUser)
                .WithMany(fu => fu.Followers)
                .HasForeignKey(uf => uf.FirstUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>()
                .HasOne(uf => uf.SecondUser)
                .WithMany(su => su.Following)
                .HasForeignKey(uf => uf.SecondUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumPicture>()
                .HasKey(ap => new { ap.AlbumId, ap.PictureId });

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Pictures)
                .WithOne(ap => ap.Album)
                .HasForeignKey(ap => ap.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Picture>()
                .HasMany(p => p.Albums)
                .WithOne(ap => ap.Picture)
                .HasForeignKey(ap => ap.PictureId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumTag>()
                .HasKey(at => new { at.AlbumId, at.TagId });

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tags)
                .WithOne(at => at.Album)
                .HasForeignKey(at => at.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Albums)
                .WithOne(at => at.Tag)
                .HasForeignKey(at => at.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAlbum>()
                .HasKey(ua => new { ua.UserId, ua.AlbumId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Albums)
                .WithOne(ua => ua.User)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.AlbumHolders)
                .WithOne(ua => ua.Album)
                .HasForeignKey(ua => ua.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}