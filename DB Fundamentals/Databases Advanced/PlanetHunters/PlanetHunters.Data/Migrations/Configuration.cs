namespace PlanetHunters.Data.Migrations
{
    using PlanetHunters.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlanetHunters.Data.PlanetHuntersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlanetHunters.Data.PlanetHuntersContext";
        }

        protected override void Seed(PlanetHunters.Data.PlanetHuntersContext context)
        {
            context.Journals.AddOrUpdate(new Journal
            {
                Name = "TestJournal"
            });

            context.SaveChanges();
        }
    }
}
