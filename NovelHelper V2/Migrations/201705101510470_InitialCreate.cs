namespace NovelHelper_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Novels",
                c => new
                    {
                        NovelId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Synopsis = c.String(),
                    })
                .PrimaryKey(t => t.NovelId);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NovelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SettingId)
                .ForeignKey("dbo.Novels", t => t.NovelId, cascadeDelete: true)
                .Index(t => t.NovelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Setting", "NovelId", "dbo.Novels");
            DropIndex("dbo.Setting", new[] { "NovelId" });
            DropTable("dbo.Setting");
            DropTable("dbo.Novels");
        }
    }
}
