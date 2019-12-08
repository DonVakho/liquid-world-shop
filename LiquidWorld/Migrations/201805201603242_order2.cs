namespace LiquidWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "OrderPlaced", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderPlaced", c => c.DateTime(nullable: false));
        }
    }
}
