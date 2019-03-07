namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tamer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "Creator_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Races", "Creator_Id");
            AddForeignKey("dbo.Races", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Races", new[] { "Creator_Id" });
            DropColumn("dbo.Races", "Creator_Id");
        }
    }
}
