namespace Dal_Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Context", c => c.Binary());
            DropColumn("dbo.Photos", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Content", c => c.String());
            DropColumn("dbo.Photos", "Context");
        }
    }
}
