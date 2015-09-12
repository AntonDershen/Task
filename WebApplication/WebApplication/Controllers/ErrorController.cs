using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Filters;

namespace WebApplication.Controllers
{
    [Culture]
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index(string error)
        {
            ViewBag.Error = error;
            return View();
        }
	}
}