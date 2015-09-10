namespace Dal_Interface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123124243423532 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "Content", c => c.String());
        }
    }
}
