namespace PlanetHunters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JournalsAndPublications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseDate = c.DateTime(nullable: false),
                        DiscoveryId = c.Int(nullable: false),
                        Journal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryId, cascadeDelete: true)
                .ForeignKey("dbo.Journals", t => t.Journal_Id)
                .Index(t => t.DiscoveryId)
                .Index(t => t.Journal_Id);
            
            DropColumn("dbo.Discoveries", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discoveries", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Publications", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.Publications", "DiscoveryId", "dbo.Discoveries");
            DropIndex("dbo.Publications", new[] { "Journal_Id" });
            DropIndex("dbo.Publications", new[] { "DiscoveryId" });
            DropTable("dbo.Publications");
            DropTable("dbo.Journals");
        }
    }
}
