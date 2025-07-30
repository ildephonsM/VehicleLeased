namespace VehicleLeasingManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Guid(nullable: false),
                        BranchName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Guid(nullable: false),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                        SupplierId = c.Guid(nullable: false),
                        BranchId = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        DriverId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.BranchId)
                .Index(t => t.ClientId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Guid(nullable: false),
                        CompanyName = c.String(),
                        ContactDetails = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Guid(nullable: false),
                        FullName = c.String(),
                        LicenseNumber = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Guid(nullable: false),
                        SupplierName = c.String(),
                        ContactInfo = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Vehicles", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Vehicles", "BranchId", "dbo.Branches");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropIndex("dbo.Vehicles", new[] { "ClientId" });
            DropIndex("dbo.Vehicles", new[] { "BranchId" });
            DropIndex("dbo.Vehicles", new[] { "SupplierId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Clients");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Branches");
        }
    }
}
