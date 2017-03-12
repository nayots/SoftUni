namespace PhotographersDB
{
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographersDBContext : DbContext
    {
        // Your context has been configured to use a 'PhotographersDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PhotographersDB.PhotographersDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotographersDBContext' 
        // connection string in the application configuration file.
        public PhotographersDBContext()
            : base("name=PhotographersDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographersDBContext, Configuration>());
        }


        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PhotographerAlbum> PhotographerAlbums { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}