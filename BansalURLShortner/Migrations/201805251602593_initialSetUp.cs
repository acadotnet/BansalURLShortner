namespace BansalURLShortner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSetUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.URLs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginalURL = c.String(),
                        ShortURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.URLs");
        }
    }
}
