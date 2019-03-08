namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racetime4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Races", "RaceTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Races", "RaceTime", c => c.DateTime(nullable: false));
        }
    }
}
