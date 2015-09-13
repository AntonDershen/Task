namespace Dal_Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Users", new[] { "Task_Id" });
            CreateTable(
                "dbo.TaskUsers",
                c => new
                    {
                        Task_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.User_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Users", "Task_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Task_Id", c => c.Int());
            DropForeignKey("dbo.TaskUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TaskUsers", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskUsers", new[] { "User_Id" });
            DropIndex("dbo.TaskUsers", new[] { "Task_Id" });
            DropTable("dbo.TaskUsers");
            CreateIndex("dbo.Users", "Task_Id");
            AddForeignKey("dbo.Users", "Task_Id", "dbo.Tasks", "Id");
        }
    }
}
