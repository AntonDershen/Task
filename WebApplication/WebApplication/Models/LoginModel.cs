using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication.App_LocalResources;

namespace WebApplication.Models
{
    public class LoginModel
    {
        [Display(Name="Email", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "EnterEmail", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(GlobalRes))]
        [Required(ErrorMessageResourceName = "EnterPassword", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }
    }
}