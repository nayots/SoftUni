namespace PlanetHunters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Astronomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discoveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TelescopeUsedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Telescopes", t => t.TelescopeUsedId, cascadeDelete: true)
                .Index(t => t.TelescopeUsedId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Mass = c.Double(nullable: false),
                        HostStarSystemId = c.Int(nullable: false),
                        Discovery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discoveries", t => t.Discovery_Id)
                .ForeignKey("dbo.StarSystems", t => t.HostStarSystemId, cascadeDelete: true)
                .Index(t => t.HostStarSystemId)
                .Index(t => t.Discovery_Id);
            
            CreateTable(
                "dbo.StarSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Temperature = c.Int(nullable: false),
                        HostStarSystemId = c.Int(nullable: false),
                        Discovery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discoveries", t => t.Discovery_Id)
                .ForeignKey("dbo.StarSystems", t => t.HostStarSystemId, cascadeDelete: true)
                .Index(t => t.HostStarSystemId)
                .Index(t => t.Discovery_Id);
            
            CreateTable(
                "dbo.Telescopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Location = c.String(nullable: false, maxLength: 255),
                        MirrorDiameter = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiscoveriesObservers",
                c => new
                    {
                        DiscoveryId = c.Int(nullable: false),
                        ObserverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscoveryId, t.ObserverId })
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryId, cascadeDelete: true)
                .ForeignKey("dbo.Astronomers", t => t.ObserverId, cascadeDelete: true)
                .Index(t => t.DiscoveryId)
                .Index(t => t.ObserverId);
            
            CreateTable(
                "dbo.DiscoveriesPioneers",
                c => new
                    {
                        DiscoveryId = c.Int(nullable: false),
                        PioneerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscoveryId, t.PioneerId })
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryId, cascadeDelete: true)
                .ForeignKey("dbo.Astronomers", t => t.PioneerId, cascadeDelete: true)
                .Index(t => t.DiscoveryId)
                .Index(t => t.PioneerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discoveries", "TelescopeUsedId", "dbo.Telescopes");
            DropForeignKey("dbo.Planets", "HostStarSystemId", "dbo.StarSystems");
            DropForeignKey("dbo.Stars", "HostStarSystemId", "dbo.StarSystems");
            DropForeignKey("dbo.Stars", "Discovery_Id", "dbo.Discoveries");
            DropForeignKey("dbo.Planets", "Discovery_Id", "dbo.Discoveries");
            DropForeignKey("dbo.DiscoveriesPioneers", "PioneerId", "dbo.Astronomers");
            DropForeignKey("dbo.DiscoveriesPioneers", "DiscoveryId", "dbo.Discoveries");
            DropForeignKey("dbo.DiscoveriesObservers", "ObserverId", "dbo.Astronomers");
            DropForeignKey("dbo.DiscoveriesObservers", "DiscoveryId", "dbo.Discoveries");
            DropIndex("dbo.DiscoveriesPioneers", new[] { "PioneerId" });
            DropIndex("dbo.DiscoveriesPioneers", new[] { "DiscoveryId" });
            DropIndex("dbo.DiscoveriesObservers", new[] { "ObserverId" });
            DropIndex("dbo.DiscoveriesObservers", new[] { "DiscoveryId" });
            DropIndex("dbo.Stars", new[] { "Discovery_Id" });
            DropIndex("dbo.Stars", new[] { "HostStarSystemId" });
            DropIndex("dbo.Planets", new[] { "Discovery_Id" });
            DropIndex("dbo.Planets", new[] { "HostStarSystemId" });
            DropIndex("dbo.Discoveries", new[] { "TelescopeUsedId" });
            DropTable("dbo.DiscoveriesPioneers");
            DropTable("dbo.DiscoveriesObservers");
            DropTable("dbo.Telescopes");
            DropTable("dbo.Stars");
            DropTable("dbo.StarSystems");
            DropTable("dbo.Planets");
            DropTable("dbo.Discoveries");
            DropTable("dbo.Astronomers");
        }
    }
}
