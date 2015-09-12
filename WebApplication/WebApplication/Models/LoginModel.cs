using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication.App_LocalResources;
using WebApplication.Filters;

namespace WebApplication.Models
{
    [Culture]
    public class LoginModel
    {
        [Display(ResourceType = typeof(GlobalRes), Name = "Email")]
        [Required(ErrorMessageResourceName = "EnterEmail", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Email { get; set; }

        [Display(ResourceType = typeof(GlobalRes), Name = "Password")]
        [Required(ErrorMessageResourceName = "EnterPassword", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }
    }
}