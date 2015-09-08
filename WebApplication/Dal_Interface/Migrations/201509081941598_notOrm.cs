namespace Dal_Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notOrm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Confirm = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Condition = c.String(),
                        Complexity = c.Int(nullable: false),
                        Category = c.String(),
                        CreateUserId = c.Int(nullable: false),
                        Activate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagTasks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Task_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TagTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TagTasks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Rates", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rates", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Photos", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Comments", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Answers", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
            DropIndex("dbo.TagTasks", new[] { "Task_Id" });
            DropIndex("dbo.TagTasks", new[] { "Tag_Id" });
            DropIndex("dbo.Rates", new[] { "TaskId" });
            DropIndex("dbo.Rates", new[] { "UserId" });
            DropIndex("dbo.Photos", new[] { "TaskId" });
            DropIndex("dbo.Answers", new[] { "TaskId" });
            DropIndex("dbo.Comments", new[] { "TaskId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Task_Id" });
            DropIndex("dbo.Authorizations", new[] { "UserId" });
            DropTable("dbo.TagTasks");
            DropTable("dbo.Tags");
            DropTable("dbo.Rates");
            DropTable("dbo.Photos");
            DropTable("dbo.Answers");
            DropTable("dbo.Tasks");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Authorizations");
        }
    }
}
