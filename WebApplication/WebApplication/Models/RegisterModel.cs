using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication.App_LocalResources;

namespace WebApplication.Models
{
    public class RegisterModel
    {
        [Display(ResourceType = typeof(GlobalRes), Name = "UserName")]
        [Required(ErrorMessageResourceName = "EnterUserName", ErrorMessageResourceType = typeof(GlobalRes))]
        public string UserName { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Email")]
        [Required(ErrorMessageResourceName = "EnterEmail", ErrorMessageResourceType = typeof(GlobalRes))]
         public string Email { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "Password")]
        [Required(ErrorMessageResourceName = "EnterPassword", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }
        [Display(ResourceType = typeof(GlobalRes), Name = "ConfirmPassword")]
        [Required(ErrorMessageResourceName = "EnterPassword", ErrorMessageResourceType = typeof(GlobalRes))]
        public string ConfirmPassword { get; set; }
    }
}