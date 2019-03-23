namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNIPPESELEMailAndPhoneNumberColumnsToVATEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VATEntities", "NIP", c => c.String(maxLength: 10));
            AddColumn("dbo.VATEntities", "PESEL", c => c.String(maxLength: 11));
            AddColumn("dbo.VATEntities", "EMail", c => c.String());
            AddColumn("dbo.VATEntities", "PhoneNumber", c => c.String());
            AlterColumn("dbo.VATEntities", "PostCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VATEntities", "PostCode", c => c.String(maxLength: 5));
            DropColumn("dbo.VATEntities", "PhoneNumber");
            DropColumn("dbo.VATEntities", "EMail");
            DropColumn("dbo.VATEntities", "PESEL");
            DropColumn("dbo.VATEntities", "NIP");
        }
    }
}
