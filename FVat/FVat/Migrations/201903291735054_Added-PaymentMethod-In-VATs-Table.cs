namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaymentMethodInVATsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VATs", "PaymentMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VATs", "PaymentMethod");
        }
    }
}
