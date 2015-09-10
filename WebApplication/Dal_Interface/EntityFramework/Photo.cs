using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] Context { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
