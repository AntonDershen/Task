﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Complexity { get; set;}
        public string Category { get; set; }
        public int CreateUserId { get; set; }
        public bool Condition { get; set; }
        public virtual ICollection<ORM.Сomment> Comments { get;set;}
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }
}