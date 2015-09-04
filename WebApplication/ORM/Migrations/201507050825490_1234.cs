namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentContexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.Int(nullable: false),
                        Context = c.Binary(),
                        DocumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
            DropColumn("dbo.Documents", "DocumentPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "DocumentPath", c => c.String());
            DropForeignKey("dbo.DocumentContexts", "DocumentId", "dbo.Documents");
            DropIndex("dbo.DocumentContexts", new[] { "DocumentId" });
            DropTable("dbo.DocumentContexts");
        }
    }
}
