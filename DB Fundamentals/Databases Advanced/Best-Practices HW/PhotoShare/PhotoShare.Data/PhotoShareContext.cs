namespace PhotoShare.Data
{
    using System.Data.Entity;

    using Models;
    using PhotoShare.Data.Migrations;

    public class PhotoShareContext : DbContext
    { 
        public PhotoShareContext() : base("name=PhotoShareContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotoShareContext>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<AlbumRole> AlbumRoles { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UsersFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}