namespace ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Constants;
    internal sealed class Configuration : DbMigrationsConfiguration<ORM.EntityModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ORM.EntityModel context)
        {
        }
    }
}
