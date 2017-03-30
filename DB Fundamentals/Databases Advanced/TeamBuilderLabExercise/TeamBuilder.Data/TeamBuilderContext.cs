namespace TeamBuilder.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TeamBuilder.Data.Configurations;
    using TeamBuilder.Models;

    public class TeamBuilderContext : DbContext
    {
        // Your context has been configured to use a 'TeamBuilderContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TeamBuilder.Data.TeamBuilderContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TeamBuilderContext' 
        // connection string in the application configuration file.
        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TeamBuilderContext>());
        }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
        }
    }
}