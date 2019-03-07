namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tamer2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Races", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Races", new[] { "Creator_Id" });
            AlterColumn("dbo.Races", "Creator_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Races", "Creator_Id");
            AddForeignKey("dbo.Races", "Creator_Id", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Races", new[] { "Creator_Id" });
            AlterColumn("dbo.Races", "Creator_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Races", "Creator_Id");
            AddForeignKey("dbo.Races", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
