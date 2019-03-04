namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        ApplicationUserId = c.String(),
                        Number = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        DateEnd = c.DateTime(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        Description = c.String(),
                        Title = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.POIs", "Inscription_Id", c => c.Int());
            AddColumn("dbo.POIs", "Race_Id", c => c.Int());
            CreateIndex("dbo.POIs", "Inscription_Id");
            CreateIndex("dbo.POIs", "Race_Id");
            AddForeignKey("dbo.POIs", "Inscription_Id", "dbo.Inscriptions", "Id");
            AddForeignKey("dbo.POIs", "Race_Id", "dbo.Races", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.POIs", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Inscriptions", "RaceId", "dbo.Races");
            DropForeignKey("dbo.POIs", "Inscription_Id", "dbo.Inscriptions");
            DropIndex("dbo.POIs", new[] { "Race_Id" });
            DropIndex("dbo.POIs", new[] { "Inscription_Id" });
            DropIndex("dbo.Inscriptions", new[] { "RaceId" });
            DropColumn("dbo.POIs", "Race_Id");
            DropColumn("dbo.POIs", "Inscription_Id");
            DropTable("dbo.Races");
            DropTable("dbo.Inscriptions");
        }
    }
}
