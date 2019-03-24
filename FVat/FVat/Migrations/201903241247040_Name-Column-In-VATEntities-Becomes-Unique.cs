namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameColumnInVATEntitiesBecomesUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VATEntities", "Name", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.VATEntities", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.VATEntities", new[] { "Name" });
            AlterColumn("dbo.VATEntities", "Name", c => c.String(nullable: false));
        }
    }
}
