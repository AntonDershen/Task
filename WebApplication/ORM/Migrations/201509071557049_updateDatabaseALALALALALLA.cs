namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabaseALALALALALLA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Category", c => c.String());
            AddColumn("dbo.Rates", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "Condition", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Сomment", "UserId");
            AddForeignKey("dbo.Сomment", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Tasks", "Section");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Section", c => c.String());
            DropForeignKey("dbo.Сomment", "UserId", "dbo.Users");
            DropIndex("dbo.Сomment", new[] { "UserId" });
            AlterColumn("dbo.Tasks", "Condition", c => c.String());
            DropColumn("dbo.Rates", "Rating");
            DropColumn("dbo.Tasks", "Category");
        }
    }
}
