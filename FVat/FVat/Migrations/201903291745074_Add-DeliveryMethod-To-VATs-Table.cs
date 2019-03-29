namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeliveryMethodToVATsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VATs", "DeliveryMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VATs", "DeliveryMethod");
        }
    }
}
