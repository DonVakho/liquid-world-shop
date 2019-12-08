namespace LiquidWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        AddressLine1 = c.String(nullable: false, maxLength: 100),
                        AddressLine2 = c.String(),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        State = c.String(maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 50),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPlaced = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DrinkId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "DrinkId", "dbo.Drinks");
            DropIndex("dbo.OrderDetails", new[] { "DrinkId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
    }
}
