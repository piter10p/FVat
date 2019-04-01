namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlaceOfIssueColumnToVATsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VATs", "PlaceOfIssue", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VATs", "PlaceOfIssue");
        }
    }
}
