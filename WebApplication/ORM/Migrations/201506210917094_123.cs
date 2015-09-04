namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AuthorizationId", "dbo.Authorizations");
            DropIndex("dbo.Users", new[] { "AuthorizationId" });
            DropColumn("dbo.Users", "AuthorizationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AuthorizationId", c => c.Int());
            CreateIndex("dbo.Users", "AuthorizationId");
            AddForeignKey("dbo.Users", "AuthorizationId", "dbo.Authorizations", "Id");
        }
    }
}
