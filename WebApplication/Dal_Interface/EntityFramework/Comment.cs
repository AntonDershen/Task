using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
