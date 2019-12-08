namespace LiquidWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "DrinkId" });
            AddColumn("dbo.ShoppingCartItems", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.ShoppingCartItems", "Order_OrderId");
            AddForeignKey("dbo.ShoppingCartItems", "Order_OrderId", "dbo.Orders", "OrderId");
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.OrderDetailId);
            
            DropForeignKey("dbo.ShoppingCartItems", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.ShoppingCartItems", new[] { "Order_OrderId" });
            DropColumn("dbo.ShoppingCartItems", "Order_OrderId");
            CreateIndex("dbo.OrderDetails", "DrinkId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "DrinkId", "dbo.Drinks", "DrinkId", cascadeDelete: true);
        }
    }
}
