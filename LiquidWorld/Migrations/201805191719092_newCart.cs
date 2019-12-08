namespace LiquidWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCartItems", "Drink_DrinkId", "dbo.Drinks");
            DropIndex("dbo.ShoppingCartItems", new[] { "Drink_DrinkId" });
            AddColumn("dbo.ShoppingCartItems", "Drink", c => c.String());
            DropColumn("dbo.ShoppingCartItems", "Drink_DrinkId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCartItems", "Drink_DrinkId", c => c.Int());
            DropColumn("dbo.ShoppingCartItems", "Drink");
            CreateIndex("dbo.ShoppingCartItems", "Drink_DrinkId");
            AddForeignKey("dbo.ShoppingCartItems", "Drink_DrinkId", "dbo.Drinks", "DrinkId");
        }
    }
}
