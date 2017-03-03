namespace SalesDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Age");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
        }
    }
}
