namespace BansalURLShortner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedURLClickTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.URLClicks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortURLNumber = c.String(),
                        URLId = c.Int(nullable: false),
                        NumberOfClicks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.URLs", t => t.URLId, cascadeDelete: true)
                .Index(t => t.URLId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.URLClicks", "URLId", "dbo.URLs");
            DropIndex("dbo.URLClicks", new[] { "URLId" });
            DropTable("dbo.URLClicks");
        }
    }
}
