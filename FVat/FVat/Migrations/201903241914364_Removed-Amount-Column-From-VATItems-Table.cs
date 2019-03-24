namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAmountColumnFromVATItemsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VATItems", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VATItems", "Amount", c => c.Double(nullable: false));
        }
    }
}
