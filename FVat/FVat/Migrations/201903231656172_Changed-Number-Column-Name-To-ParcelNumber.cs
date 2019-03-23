namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNumberColumnNameToParcelNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VATEntities", "ParcelNumber", c => c.String(nullable: false, maxLength: 16));
            DropColumn("dbo.VATEntities", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VATEntities", "Number", c => c.String(nullable: false, maxLength: 16));
            DropColumn("dbo.VATEntities", "ParcelNumber");
        }
    }
}
