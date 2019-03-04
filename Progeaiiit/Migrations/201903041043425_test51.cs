namespace Progeaiiit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.POIs", "CooX", c => c.Double(nullable: false));
            AlterColumn("dbo.POIs", "CooY", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.POIs", "CooY", c => c.Int(nullable: false));
            AlterColumn("dbo.POIs", "CooX", c => c.Int(nullable: false));
        }
    }
}
