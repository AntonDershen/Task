using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public EntityModel()
            : base("name=EntityModel")
        {
        }
    }
}