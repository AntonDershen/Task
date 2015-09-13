using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class UserAnswers
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public bool TrueAnswer { get; set; }
        public bool FirstAnswer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
