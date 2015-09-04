using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
      
        public ActionResult Index()
        {
            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = Constants.Constant.welcome + User.Identity.Name;
            }
            ViewBag.Identity = result;
            return View();
        }
    }
}