namespace FVat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVATstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VATs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuerId = c.Int(),
                        ReceiverId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VATEntities", t => t.IssuerId)
                .ForeignKey("dbo.VATEntities", t => t.ReceiverId)
                .Index(t => t.IssuerId)
                .Index(t => t.ReceiverId)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VATs", "ReceiverId", "dbo.VATEntities");
            DropForeignKey("dbo.VATs", "IssuerId", "dbo.VATEntities");
            DropIndex("dbo.VATs", new[] { "Name" });
            DropIndex("dbo.VATs", new[] { "ReceiverId" });
            DropIndex("dbo.VATs", new[] { "IssuerId" });
            DropTable("dbo.VATs");
        }
    }
}
