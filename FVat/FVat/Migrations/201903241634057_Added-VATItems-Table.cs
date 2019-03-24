namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVATItemsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VATItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Unit = c.Int(nullable: false),
                        VATRate = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.VATItems", new[] { "Name" });
            DropTable("dbo.VATItems");
        }
    }
}
