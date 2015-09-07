using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    public  class EntityModel : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<ORM.Сomment> Comments { get; set; }
        public EntityModel()
            : base("name=EntityModel")
        {
        }
    }
}