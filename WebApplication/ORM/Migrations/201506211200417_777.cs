namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _777 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authorizations", "Email", c => c.String());
            DropColumn("dbo.Authorizations", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authorizations", "Login", c => c.String());
            DropColumn("dbo.Authorizations", "Email");
        }
    }
}
