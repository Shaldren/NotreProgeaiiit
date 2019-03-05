namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class position : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Order = c.Int(nullable: false),
                        POI_Id = c.Int(nullable: false),
                        Race_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order, t.POI_Id, t.Race_Id })
                .ForeignKey("dbo.POIs", t => t.POI_Id, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.Race_Id, cascadeDelete: true)
                .Index(t => t.POI_Id)
                .Index(t => t.Race_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Positions", "POI_Id", "dbo.POIs");
            DropIndex("dbo.Positions", new[] { "Race_Id" });
            DropIndex("dbo.Positions", new[] { "POI_Id" });
            DropTable("dbo.Positions");
        }
    }
}
