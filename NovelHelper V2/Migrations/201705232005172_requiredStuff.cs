namespace NovelHelper_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredStuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Character", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Novels", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Setting", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Setting", "Name", c => c.String());
            AlterColumn("dbo.Novels", "Title", c => c.String());
            AlterColumn("dbo.Character", "Name", c => c.String());
        }
    }
}
