using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        public int CreateUserId { get; set; }
        public double Rate { get; set; }
        public bool Activate { get; set; }
        public string Condition { get; set; }
        public List<string> Answers { get; set; }
        public List<int> TagsId { get; set; }
      
    }
}
