namespace IteraTestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Returnvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodOrders", "DishName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodOrders", "DishName", c => c.String());
        }
    }
}
