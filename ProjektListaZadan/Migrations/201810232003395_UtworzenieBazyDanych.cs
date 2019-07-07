namespace ProjektListaZadan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Mapuje i tworzy bazê danych
    /// Klasa utworzona automatycznie poprzez Entity Framework
    /// </summary>
    public partial class UtworzenieBazyDanych : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKategori = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Uzytkowniks",
                c => new
                    {
                        UzytkownikID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Haslo = c.String(),
                    })
                .PrimaryKey(t => t.UzytkownikID);
            
            CreateTable(
                "dbo.Zadanies",
                c => new
                    {
                        ZadanieId = c.Int(nullable: false, identity: true),
                        NazwaZadania = c.String(),
                        StatusZadania = c.Boolean(nullable: false),
                        KategoriaId = c.Int(nullable: false),
                        UzytkownikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZadanieId)
                .ForeignKey("dbo.Kategorias", t => t.KategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Uzytkowniks", t => t.UzytkownikId, cascadeDelete: true)
                .Index(t => t.KategoriaId)
                .Index(t => t.UzytkownikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zadanies", "UzytkownikId", "dbo.Uzytkowniks");
            DropForeignKey("dbo.Zadanies", "KategoriaId", "dbo.Kategorias");
            DropIndex("dbo.Zadanies", new[] { "UzytkownikId" });
            DropIndex("dbo.Zadanies", new[] { "KategoriaId" });
            DropTable("dbo.Zadanies");
            DropTable("dbo.Uzytkowniks");
            DropTable("dbo.Kategorias");
        }
    }
}
