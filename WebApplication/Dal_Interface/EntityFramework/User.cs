using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
