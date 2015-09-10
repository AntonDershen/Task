using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
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
            string result = "You are not logged in!";
            if (User.Identity.IsAuthenticated)
            {
                result = User.Identity.Name;
            }
            ViewBag.Identity = result;
            return View();
        }

        //public ActionResult ChangeCulture(string language)
        //{
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

        //    Session["CurrentCulture"] = language;   
            
        //    var returnUrl = Request.UrlReferrer.OriginalString;
        //    var cookie = Request.Cookies["lang"];
        //    if (cookie != null)
        //        cookie.Value = language;
        //    else
        //    {
        //        cookie = new HttpCookie("lang");
        //        cookie.HttpOnly = false;
        //        cookie.Value = language;
        //        cookie.Expires = DateTime.Now.AddYears(1);
        //    }
        //    Response.Cookies.Add(cookie);

        //    return Redirect(returnUrl);
        //} 
        //protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        //{
        //    base.Initialize(requestContext);
        //    if (Session["CurrentCulture"] != null)
        //    {
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
        //    }
        //}
        //public ActionResult ChangeCulture(string ddlCulture)
        //{
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

        //    Session["CurrentCulture"] = ddlCulture;
        //    return View("Index");
        //}

    }
}