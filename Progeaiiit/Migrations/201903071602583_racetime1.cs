namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racetime1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Races", "RaceTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "RaceTime", c => c.DateTime(nullable: false));
        }
    }
}
