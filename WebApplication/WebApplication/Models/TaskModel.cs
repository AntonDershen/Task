using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication.App_LocalResources;
using WebApplication.Filters;

namespace WebApplication.Models
{
    [Culture]
    public class CreateTaskModel
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Name")]
        public string Name { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Complexity")]
        public int Complexity { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Category")]
        public string Category { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Condition")]
        [AllowHtml]
        public string Condition { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Tag")]
        public List<string> Tag { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Answers")]
        public List<string> Answers { get; set; }
    }

}