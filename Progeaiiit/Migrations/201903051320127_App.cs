namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class App : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InscriptionPOIs", "Inscription_Id", "dbo.Inscriptions");
            DropForeignKey("dbo.InscriptionPOIs", "POI_Id", "dbo.POIs");
            DropForeignKey("dbo.Positions", "POI_Id", "dbo.POIs");
            DropIndex("dbo.Positions", new[] { "POI_Id" });
            DropIndex("dbo.InscriptionPOIs", new[] { "Inscription_Id" });
            DropIndex("dbo.InscriptionPOIs", new[] { "POI_Id" });
            DropPrimaryKey("dbo.Positions");
            AddColumn("dbo.Positions", "Inscription_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "Inscription_Id1", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Positions", new[] { "Order", "Race_Id", "Inscription_Id" });
            CreateIndex("dbo.Positions", "Inscription_Id1");
            AddForeignKey("dbo.Positions", "Inscription_Id1", "dbo.Inscriptions", "Id");
            DropColumn("dbo.Positions", "POI_Id");
            DropTable("dbo.InscriptionPOIs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InscriptionPOIs",
                c => new
                    {
                        Inscription_Id = c.Int(nullable: false),
                        POI_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inscription_Id, t.POI_Id });
            
            AddColumn("dbo.Positions", "POI_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Positions", "Inscription_Id1", "dbo.Inscriptions");
            DropIndex("dbo.Positions", new[] { "Inscription_Id1" });
            DropPrimaryKey("dbo.Positions");
            DropColumn("dbo.Positions", "Inscription_Id1");
            DropColumn("dbo.Positions", "Inscription_Id");
            AddPrimaryKey("dbo.Positions", new[] { "Order", "POI_Id", "Race_Id" });
            CreateIndex("dbo.InscriptionPOIs", "POI_Id");
            CreateIndex("dbo.InscriptionPOIs", "Inscription_Id");
            CreateIndex("dbo.Positions", "POI_Id");
            AddForeignKey("dbo.Positions", "POI_Id", "dbo.POIs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InscriptionPOIs", "POI_Id", "dbo.POIs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InscriptionPOIs", "Inscription_Id", "dbo.Inscriptions", "Id", cascadeDelete: true);
        }
    }
}
