namespace ProductShop.Data
{
    using ProductShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {
        // Your context has been configured to use a 'ProductShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductShop.Data.ProductShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductShopContext' 
        // connection string in the application configuration file.
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ProductShopContext>());
        }


        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Friends)
                .WithMany()
                .Map(r => {
                    r.ToTable("UserFriends");
                    r.MapRightKey("FriendId");
                    r.MapLeftKey("UserId");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold)
                .WithRequired(p => p.Seller);


            base.OnModelCreating(modelBuilder);
        }
    }

}