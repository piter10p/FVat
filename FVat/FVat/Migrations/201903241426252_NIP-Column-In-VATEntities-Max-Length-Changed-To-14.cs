namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NIPColumnInVATEntitiesMaxLengthChangedTo14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VATEntities", "NIP", c => c.String(maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VATEntities", "NIP", c => c.String(maxLength: 10));
        }
    }
}
