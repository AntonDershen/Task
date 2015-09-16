using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class UserAchievement
    {
        public int Id { get; set; }
        public int TaskCreated { get; set; }
        public int TaskAnswered { get; set; }
        public int FirstAnswered { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
