namespace StudentSystemDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLicenses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "ResourceId", "dbo.Resources");
            DropIndex("dbo.Licenses", new[] { "ResourceId" });
            DropTable("dbo.Licenses");
        }
    }
}
