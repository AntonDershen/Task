using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;
            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            cultureName = cultureCookie != null ? cultureCookie.Value : "en";

            var cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "en";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}

//public class HomeController : Controller
//{
//    //initilizing culture on controller initialization
//    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
//    {
//        base.Initialize(requestContext);
//        if (Session["CurrentCulture"] != null)
//        {
//            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
//            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
//        }
//    }

//    // changing culture
//    public ActionResult ChangeCulture(string ddlCulture)
//    {
//        Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
//        Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

//        Session["CurrentCulture"] = ddlCulture;
//        return View("Index");
//    }
//}