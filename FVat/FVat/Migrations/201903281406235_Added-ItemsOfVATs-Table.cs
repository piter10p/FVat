namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItemsOfVATsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemOfVATs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        VATItemId = c.Int(nullable: false),
                        VATId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VATs", t => t.VATId, cascadeDelete: true)
                .ForeignKey("dbo.VATItems", t => t.VATItemId, cascadeDelete: true)
                .Index(t => t.VATItemId)
                .Index(t => t.VATId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOfVATs", "VATItemId", "dbo.VATItems");
            DropForeignKey("dbo.ItemOfVATs", "VATId", "dbo.VATs");
            DropIndex("dbo.ItemOfVATs", new[] { "VATId" });
            DropIndex("dbo.ItemOfVATs", new[] { "VATItemId" });
            DropTable("dbo.ItemOfVATs");
        }
    }
}
