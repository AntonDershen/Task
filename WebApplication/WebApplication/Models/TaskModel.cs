using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebApplication.Models
{
    public class CreateTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        [AllowHtml]
        public string Condition { get; set; }
        public List<string> Tag { get; set; }
        public List<string> Answers { get; set; }
    }
    public class ViewTaskModel
    {
        public string Name { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        [AllowHtml]
        public string Condition { get; set; }
        public List<int> TagsId { get; set; }
        public List<int> PhotoId { get; set; }
    }
}