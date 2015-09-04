using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using BusinessLogic.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using System.Web.Security;
using Constants;
namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthorizationService authService;
        public AccountController(IUserService userService, IAuthorizationService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (ModelState.IsValid)
                {
                    if (authService.CheckForm(model.ToAuthorizationEntity()))
                    {
                        FormsAuthentication.SetAuthCookie(userService.Find((authService.Get(x=>x.Email == model.Email).UserId)).UserName, true);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", Constant.errorAuth);
                }
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (model.ConfirmPassword != model.Password)
            {
                ModelState.AddModelError("", Constant.errorPassword);
                return View(model);
            }
            if (ModelState.IsValid)
            {
                
                int id = userService.CreateUser(model.ToUserEntity());
                if (id>0)
                {
                    
                    authService.CreateAuthorization(model.ToAuthorizationEntity(id));
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", Constant.userExist);
                   
            }
          return View(model);
         }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
	}
}