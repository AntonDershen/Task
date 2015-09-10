using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Interface.EntityFramework
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
