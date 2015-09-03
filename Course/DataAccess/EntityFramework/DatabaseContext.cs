using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DataAccess.Entities;
namespace DataAccess.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Authorization> Authorization { get; set; }
        public DatabaseContext():base("name=DefaultConnection")
        { }
        public DatabaseContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
