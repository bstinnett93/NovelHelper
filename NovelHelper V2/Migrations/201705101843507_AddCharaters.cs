namespace NovelHelper_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharaters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NovelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Novels", t => t.NovelId, cascadeDelete: true)
                .Index(t => t.NovelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "NovelId", "dbo.Novels");
            DropIndex("dbo.Character", new[] { "NovelId" });
            DropTable("dbo.Character");
        }
    }
}
