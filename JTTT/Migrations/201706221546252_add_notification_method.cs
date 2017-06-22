namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_notification_method : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "notification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "notification");
        }
    }
}
