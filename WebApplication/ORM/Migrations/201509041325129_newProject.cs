namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentContexts", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropIndex("dbo.DocumentContexts", new[] { "DocumentId" });
            DropColumn("dbo.Users", "RoleId");
            DropTable("dbo.Documents");
            DropTable("dbo.DocumentContexts");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentContexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.Int(nullable: false),
                        Context = c.Binary(),
                        DocumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Access = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.DocumentContexts", "DocumentId");
            CreateIndex("dbo.Documents", "UserId");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.Documents", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentContexts", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
        }
    }
}
