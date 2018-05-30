namespace BansalURLShortner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.URLs", "OriginalURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.URLs", "OriginalURL", c => c.String());
        }
    }
}
