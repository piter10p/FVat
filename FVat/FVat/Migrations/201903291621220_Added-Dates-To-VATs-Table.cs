namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatesToVATsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VATs", "DateOfIssue", c => c.DateTime(nullable: false));
            AddColumn("dbo.VATs", "DateOfService", c => c.DateTime(nullable: false));
            AddColumn("dbo.VATs", "DateOfPayment", c => c.DateTime());
            AddColumn("dbo.VATs", "PaymentTermDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VATs", "PaymentTermDate");
            DropColumn("dbo.VATs", "DateOfPayment");
            DropColumn("dbo.VATs", "DateOfService");
            DropColumn("dbo.VATs", "DateOfIssue");
        }
    }
}
