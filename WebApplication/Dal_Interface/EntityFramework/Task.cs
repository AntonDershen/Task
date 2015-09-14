using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class Task : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public bool Activate { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public int RateCount { get; set; }
        public double Rate { get; set; }
        public virtual ICollection<UserAnswers> UserAnswers { get; set; }
     
    }
}
