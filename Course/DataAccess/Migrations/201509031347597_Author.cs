namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Author : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthentificationParametres", newName: "Authorizations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Authorizations", newName: "AuthentificationParametres");
        }
    }
}
