namespace NovelHelper_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Novels", "DateAccessed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Novels", "DateAccessed");
        }
    }
}
