using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskId{get;set;}
        public bool IsSolved { get; set; }
        public int Count { get; set; }
    }
}
