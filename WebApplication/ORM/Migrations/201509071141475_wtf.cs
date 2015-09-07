namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TaskId);
            
            AddColumn("dbo.Tasks", "CreateUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Tasks", "Rating");
            DropColumn("dbo.Tasks", "CountOfRate");
            DropColumn("dbo.Tasks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "CountOfRate", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Rating", c => c.Double(nullable: false));
            DropForeignKey("dbo.Rates", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rates", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Rates", new[] { "TaskId" });
            DropIndex("dbo.Rates", new[] { "UserId" });
            DropColumn("dbo.Tasks", "CreateUserId");
            DropTable("dbo.Rates");
        }
    }
}
