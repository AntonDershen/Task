namespace Dal_Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class achievement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAchievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskCreated = c.Int(nullable: false),
                        TaskAnswered = c.Int(nullable: false),
                        FirstAnswered = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAchievements", "UserId", "dbo.Users");
            DropIndex("dbo.UserAchievements", new[] { "UserId" });
            DropTable("dbo.UserAchievements");
        }
    }
}
