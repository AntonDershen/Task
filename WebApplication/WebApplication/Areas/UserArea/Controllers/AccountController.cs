using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace WebApplication.Areas.UserArea.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /UserArea/Account/
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}