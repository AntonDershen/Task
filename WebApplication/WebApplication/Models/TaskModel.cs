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
        [Required]
        public string Name { get; set; }
        
        [Display(ResourceType = typeof(GlobalRes), Name = "Complexity")]
        [Required]
        public int Complexity { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Category")]
        [Required]
        public string Category { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Condition")]
        [Required]
        [AllowHtml]
        public string Condition { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Tag")]
        [Required]
        public List<string> Tag { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Answers")]
        [Required]
        public List<string> Answers { get; set; }
    }
    public class ViewTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        [AllowHtml]
        public string Condition { get; set; }
        public List<int> TagsId { get; set; }
        public List<int> PhotoId { get; set; }
    }

}