namespace JTTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ImgURL = c.String(),
                        Description = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.ModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Models");
        }
    }
}
