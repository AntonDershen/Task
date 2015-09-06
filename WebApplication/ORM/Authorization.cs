using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class Authorization
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Confirm { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
