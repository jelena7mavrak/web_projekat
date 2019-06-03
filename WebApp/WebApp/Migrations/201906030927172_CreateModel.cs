namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        StreetName = c.String(),
                        StreetNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coefficients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coefficient = c.Double(nullable: false),
                        CustomerType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        BirthdayDate = c.DateTime(nullable: false),
                        Picture = c.String(),
                        PassengerType = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.PricelistItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Coefficients_Id = c.Int(),
                        Item_Id = c.Int(),
                        Pricelist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coefficients", t => t.Coefficients_Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Pricelists", t => t.Pricelist_Id)
                .Index(t => t.Coefficients_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Pricelist_Id);
            
            CreateTable(
                "dbo.Pricelists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteNumber = c.Int(nullable: false),
                        RouteType = c.Int(nullable: false),
                        Schedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id)
                .Index(t => t.Schedule_Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Passenger = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StationRoutes",
                c => new
                    {
                        Station_Id = c.Int(nullable: false),
                        Route_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Station_Id, t.Route_Id })
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.Route_Id, cascadeDelete: true)
                .Index(t => t.Station_Id)
                .Index(t => t.Route_Id);
            
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Routes", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.StationRoutes", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.StationRoutes", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.Stations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Stations", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.PricelistItems", "Pricelist_Id", "dbo.Pricelists");
            DropForeignKey("dbo.PricelistItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.PricelistItems", "Coefficients_Id", "dbo.Coefficients");
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.StationRoutes", new[] { "Route_Id" });
            DropIndex("dbo.StationRoutes", new[] { "Station_Id" });
            DropIndex("dbo.Stations", new[] { "Location_Id" });
            DropIndex("dbo.Stations", new[] { "Address_Id" });
            DropIndex("dbo.Routes", new[] { "Schedule_Id" });
            DropIndex("dbo.PricelistItems", new[] { "Pricelist_Id" });
            DropIndex("dbo.PricelistItems", new[] { "Item_Id" });
            DropIndex("dbo.PricelistItems", new[] { "Coefficients_Id" });
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropTable("dbo.StationRoutes");
            DropTable("dbo.Tickets");
            DropTable("dbo.Schedules");
            DropTable("dbo.Stations");
            DropTable("dbo.Routes");
            DropTable("dbo.Pricelists");
            DropTable("dbo.PricelistItems");
            DropTable("dbo.People");
            DropTable("dbo.Locations");
            DropTable("dbo.Items");
            DropTable("dbo.Coefficients");
            DropTable("dbo.Addresses");
        }
    }
}
