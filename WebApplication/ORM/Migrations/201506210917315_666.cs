namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _666 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Authorizations");
            AlterColumn("dbo.Authorizations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Authorizations", "Id");
            CreateIndex("dbo.Authorizations", "Id");
            AddForeignKey("dbo.Authorizations", "Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authorizations", "Id", "dbo.Users");
            DropIndex("dbo.Authorizations", new[] { "Id" });
            DropPrimaryKey("dbo.Authorizations");
            AlterColumn("dbo.Authorizations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authorizations", "Id");
        }
    }
}
