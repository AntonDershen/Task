namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class absss : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Answers", new[] { "TaskId" });
            DropTable("dbo.Answers");
        }
    }
}
