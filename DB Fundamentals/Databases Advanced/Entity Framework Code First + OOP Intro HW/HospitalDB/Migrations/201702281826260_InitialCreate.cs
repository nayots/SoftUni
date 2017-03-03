namespace HospitalDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Comments = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 120),
                        LastName = c.String(nullable: false, maxLength: 120),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Picture = c.Binary(),
                        IsInsured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comments = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.PatientMedicaments",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Medicament_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Medicament_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Medicaments", t => t.Medicament_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Medicament_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitations", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.PatientMedicaments", "Medicament_Id", "dbo.Medicaments");
            DropForeignKey("dbo.PatientMedicaments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Diagnoses", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.PatientMedicaments", new[] { "Medicament_Id" });
            DropIndex("dbo.PatientMedicaments", new[] { "Patient_Id" });
            DropIndex("dbo.Visitations", new[] { "Patient_Id" });
            DropIndex("dbo.Diagnoses", new[] { "Patient_Id" });
            DropTable("dbo.PatientMedicaments");
            DropTable("dbo.Visitations");
            DropTable("dbo.Patients");
            DropTable("dbo.Medicaments");
            DropTable("dbo.Diagnoses");
        }
    }
}
