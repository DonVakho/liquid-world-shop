namespace LiquidWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uodated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCartItems", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCartItems", "price");
        }
    }
}
