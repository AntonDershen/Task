using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.App_LocalResources;
using WebApplication.Filters;

namespace WebApplication.Models
{
    [Culture]
    public class UserModel
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "UserName")]
        public string UserName { get; set; }
    }
}