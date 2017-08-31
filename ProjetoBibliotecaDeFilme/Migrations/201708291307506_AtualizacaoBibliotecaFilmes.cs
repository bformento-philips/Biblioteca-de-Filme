namespace ProjetoBibliotecaDeFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoBibliotecaFilmes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        FilmeId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FilmeId);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.GeneroFilme",
                c => new
                    {
                        Genero_GeneroId = c.Int(nullable: false),
                        Filme_FilmeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genero_GeneroId, t.Filme_FilmeId })
                .ForeignKey("dbo.Genero", t => t.Genero_GeneroId, cascadeDelete: true)
                .ForeignKey("dbo.Filme", t => t.Filme_FilmeId, cascadeDelete: true)
                .Index(t => t.Genero_GeneroId)
                .Index(t => t.Filme_FilmeId);
            
            CreateTable(
                "dbo.IdiomaFilme",
                c => new
                    {
                        Idioma_IdiomaId = c.String(nullable: false, maxLength: 9),
                        Filme_FilmeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Idioma_IdiomaId, t.Filme_FilmeId })
                .ForeignKey("dbo.Idioma", t => t.Idioma_IdiomaId, cascadeDelete: true)
                .ForeignKey("dbo.Filme", t => t.Filme_FilmeId, cascadeDelete: true)
                .Index(t => t.Idioma_IdiomaId)
                .Index(t => t.Filme_FilmeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdiomaFilme", "Filme_FilmeId", "dbo.Filme");
            DropForeignKey("dbo.IdiomaFilme", "Idioma_IdiomaId", "dbo.Idioma");
            DropForeignKey("dbo.GeneroFilme", "Filme_FilmeId", "dbo.Filme");
            DropForeignKey("dbo.GeneroFilme", "Genero_GeneroId", "dbo.Genero");
            DropIndex("dbo.IdiomaFilme", new[] { "Filme_FilmeId" });
            DropIndex("dbo.IdiomaFilme", new[] { "Idioma_IdiomaId" });
            DropIndex("dbo.GeneroFilme", new[] { "Filme_FilmeId" });
            DropIndex("dbo.GeneroFilme", new[] { "Genero_GeneroId" });
            DropTable("dbo.IdiomaFilme");
            DropTable("dbo.GeneroFilme");
            DropTable("dbo.Genero");
            DropTable("dbo.Filme");
        }
    }
}
