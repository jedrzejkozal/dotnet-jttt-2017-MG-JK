namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "action");
        }
    }
}
