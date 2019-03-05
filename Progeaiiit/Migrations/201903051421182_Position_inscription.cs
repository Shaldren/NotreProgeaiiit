namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Position_inscription : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Positions", "Inscription_Id1", "dbo.Inscriptions");
            DropIndex("dbo.Positions", new[] { "Race_Id" });
            DropIndex("dbo.Positions", new[] { "Inscription_Id1" });
            AddColumn("dbo.Inscriptions", "Time", c => c.String());
            DropTable("dbo.Positions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Order = c.Int(nullable: false),
                        Race_Id = c.Int(nullable: false),
                        Inscription_Id = c.Int(nullable: false),
                        Inscription_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order, t.Race_Id, t.Inscription_Id });
            
            DropColumn("dbo.Inscriptions", "Time");
            CreateIndex("dbo.Positions", "Inscription_Id1");
            CreateIndex("dbo.Positions", "Race_Id");
            AddForeignKey("dbo.Positions", "Inscription_Id1", "dbo.Inscriptions", "Id");
            AddForeignKey("dbo.Positions", "Race_Id", "dbo.Races", "Id", cascadeDelete: true);
        }
    }
}
