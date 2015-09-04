using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class LoginModel
    {
        [Display(Name="Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}