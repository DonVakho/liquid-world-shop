namespace LiquidWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        ShoppingCartItemId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Drink_DrinkId = c.Int(),
                    })
                .PrimaryKey(t => t.ShoppingCartItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShoppingCartItems");
        }
    }
}
