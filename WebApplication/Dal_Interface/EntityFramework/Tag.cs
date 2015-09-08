using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
