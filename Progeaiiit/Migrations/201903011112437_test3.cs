namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisplayConfigurations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeviceName = c.String(),
                        SpeedAvg = c.Boolean(nullable: false),
                        SpeedMax = c.Boolean(nullable: false),
                        UnitDistance = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.POIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CooX = c.Int(nullable: false),
                        CooY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.POIs");
            DropTable("dbo.DisplayConfigurations");
            DropTable("dbo.Categories");
        }
    }
}
