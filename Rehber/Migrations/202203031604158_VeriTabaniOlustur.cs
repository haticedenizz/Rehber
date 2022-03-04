namespace Rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeriTabaniOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kisis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        CepTelefon = c.String(),
                        EmailAdres = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kisis");
        }
    }
}
