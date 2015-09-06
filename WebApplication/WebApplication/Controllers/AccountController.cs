﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using BusinessLogic.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using System.Web.Security;
using System.Net.Mail;
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
                    ModelState.AddModelError("", "");
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
                ModelState.AddModelError("", "");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                
                int id = userService.CreateUser(model.ToUserEntity(),model.Email);
                if (id>0)
                {
                    authService.CreateAuthorization(model.ToAuthorizationEntity(id));
                    sendEmail(model.Email, id);
                    return RedirectToAction("Confirm", "Account", new { email = model.Email });
                }
                ModelState.AddModelError("", "");
                   
            }
          return View(model);
         }
        [AllowAnonymous]
        public string Confirm(string email)
        {
            return "На почтовый адрес " + email + " Вам высланы дальнейшие" +
                    "инструкции по завершению регистрации";
        }
        [AllowAnonymous]
        public ActionResult ConfirmEmail(string token, string email)
        {
            var authorizations = userService.GetAuthorization(Int32.Parse(token));
            foreach (var authorization in authorizations)
            {
                if (authorization.Email == email)
                {
                    authorization.Confirm = true;
                    authService.UpdateAuthorization(authorization);
                    return RedirectToAction("Home", "Index");
                }
                
            }
            return RedirectToAction("Home", "Index");
        }
        private void sendEmail(string email,int id)
        {
            MailAddress from = new MailAddress("dershen95@gmail.com", "Registration to IntransitionTask");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Email confirmation";
            m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" + 
                            "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                Url.Action("ConfirmEmail", "Account", new { token = id, email = email }, Request.Url.Scheme));
            m.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new System.Net.NetworkCredential("dershen95@gmail.com", "Dershen2013");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
	}
}