namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coefficients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coefficient = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
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
                "dbo.PricelistItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        ItemId = c.Int(nullable: false),
                        PricelistId = c.Int(nullable: false),
                        Coefficient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coefficients", t => t.Coefficient_Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Pricelists", t => t.PricelistId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.PricelistId)
                .Index(t => t.Coefficient_Id);
            
            CreateTable(
                "dbo.Pricelists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        InUse = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StationId = c.Int(nullable: false),
                        RouteNumber = c.Int(nullable: false),
                        RouteType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StatioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        LineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatioId)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        DepartureTime = c.String(),
                        LineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);
            
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
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthdayDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Picture", c => c.String());
            AddColumn("dbo.AspNetUsers", "PassengerType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Stations", "LineId", "dbo.Lines");
            DropForeignKey("dbo.PricelistItems", "PricelistId", "dbo.Pricelists");
            DropForeignKey("dbo.PricelistItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PricelistItems", "Coefficient_Id", "dbo.Coefficients");
            DropIndex("dbo.Schedules", new[] { "LineId" });
            DropIndex("dbo.Stations", new[] { "LineId" });
            DropIndex("dbo.PricelistItems", new[] { "Coefficient_Id" });
            DropIndex("dbo.PricelistItems", new[] { "PricelistId" });
            DropIndex("dbo.PricelistItems", new[] { "ItemId" });
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "PassengerType");
            DropColumn("dbo.AspNetUsers", "Picture");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "BirthdayDate");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Tickets");
            DropTable("dbo.Schedules");
            DropTable("dbo.Stations");
            DropTable("dbo.Lines");
            DropTable("dbo.Pricelists");
            DropTable("dbo.PricelistItems");
            DropTable("dbo.Locations");
            DropTable("dbo.Items");
            DropTable("dbo.Coefficients");
        }
    }
}
