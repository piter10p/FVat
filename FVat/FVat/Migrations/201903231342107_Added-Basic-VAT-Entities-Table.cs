namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBasicVATEntitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VATEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        Number = c.String(nullable: false, maxLength: 16),
                        PostCode = c.String(maxLength: 5),
                        PostCity = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VATEntities");
        }
    }
}
