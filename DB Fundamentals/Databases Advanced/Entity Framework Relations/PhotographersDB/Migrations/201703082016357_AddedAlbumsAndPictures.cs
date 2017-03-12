namespace PhotographersDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbumsAndPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BackgroundColor = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        PhotographerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.PhotographerId, cascadeDelete: true)
                .Index(t => t.PhotographerId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Caption = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PictureAlbums",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Album_Id })
                .ForeignKey("dbo.Pictures", t => t.Picture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Picture_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.PictureAlbums", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.Albums", "PhotographerId", "dbo.Photographers");
            DropIndex("dbo.PictureAlbums", new[] { "Album_Id" });
            DropIndex("dbo.PictureAlbums", new[] { "Picture_Id" });
            DropIndex("dbo.Albums", new[] { "PhotographerId" });
            DropTable("dbo.PictureAlbums");
            DropTable("dbo.Pictures");
            DropTable("dbo.Albums");
        }
    }
}
