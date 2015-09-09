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
        [Display(ResourceType = typeof(GlobalRes),Name = "Field_Email")]
        [Required(ErrorMessageResourceName = "Field_EnterEmail", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Email { get; set; }

        [Display(ResourceType = typeof(GlobalRes), Name = "Field_Password")]
        [Required(ErrorMessageResourceName = "Field_EnterPassword", ErrorMessageResourceType = typeof(GlobalRes))]
        public string Password { get; set; }
    }
}