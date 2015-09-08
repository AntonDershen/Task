using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CreateTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public List<string> Tag { get; set; }
        public List<string> Answers { get; set; }
    }
}