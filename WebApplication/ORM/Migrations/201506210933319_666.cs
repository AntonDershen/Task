namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _666 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authorizations", "Id", "dbo.Users");
            DropIndex("dbo.Authorizations", new[] { "Id" });
            DropPrimaryKey("dbo.Authorizations");
            AddColumn("dbo.Authorizations", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Authorizations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authorizations", "Id");
            CreateIndex("dbo.Authorizations", "UserId");
            AddForeignKey("dbo.Authorizations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
            DropIndex("dbo.Authorizations", new[] { "UserId" });
            DropPrimaryKey("dbo.Authorizations");
            AlterColumn("dbo.Authorizations", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Authorizations", "UserId");
            AddPrimaryKey("dbo.Authorizations", "Id");
            CreateIndex("dbo.Authorizations", "Id");
            AddForeignKey("dbo.Authorizations", "Id", "dbo.Users", "Id");
        }
    }
}
