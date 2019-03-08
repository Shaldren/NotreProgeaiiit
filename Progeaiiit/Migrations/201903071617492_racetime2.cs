namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racetime2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "RaceTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Races", "RaceTime");
        }
    }
}
