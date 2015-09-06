namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Confirm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authorizations", "Confirm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authorizations", "Confirm");
        }
    }
}
