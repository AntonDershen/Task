using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using BusinessLogic.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Filters;
using System.Web.Security;
using System.Net.Mail;
using WebApplication.App_LocalResources;

namespace WebApplication.Controllers
{
    [Culture]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthorizationService authService;
        private readonly IAnswerService answerService;
        private readonly ITaskService taskService;
        public AccountController(IUserService userService, IAuthorizationService authService, IAnswerService answerService, ITaskService taskService)
        {
            this.userService = userService;
            this.authService = authService;
            this.answerService = answerService;
            this.taskService = taskService;
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
                    if (authService.CheckForm(model.ToAuthorizationEntity()))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "");
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
                    SendEmail(model.Email, id);
                    return RedirectToAction("Confirm", "Account", new { email = model.Email });
                }
                ModelState.AddModelError("", "");
                   
            }
          return View(model);
         }
        [AllowAnonymous]
        public string Confirm(string email)
        {
            return GlobalRes.PostalAddress + email + GlobalRes.SentFurtherInstructions;
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
        private void SendEmail(string email,int id)
        {
            MailAddress from = new MailAddress("dershen95@gmail.com", "Registration to IntransitionTask");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = GlobalRes.EmailConfirmation;
            m.Body = string.Format(GlobalRes.CompleteRegistration +  "<a href=\"{0}\" title=\"Submit registration\">{0}</a>",
                Url.Action("ConfirmEmail", "Account", new { token = id, email = email }, Request.Url.Scheme));
            m.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            // login and email
            smtp.Credentials = new System.Net.NetworkCredential("dershen95@gmail.com", "antonDershen");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public ActionResult Profile()
        {
            var user = userService.Find(userService.GetUserId(User.Identity.Name)).ToMvcUser();
            var answersUserId = answerService.GetUsersSolvedAnswer(user.Id).Select(x => x.TaskId);
            double complexity = 0;
            foreach (var answerUserId in answersUserId)
                complexity += taskService.Find(answerUserId).Complexity;
            ViewBag.UserRate = complexity;
            ViewBag.AchivementLevel = userService.GetUserAchivement(user.Id);
            return View(user);
        }
        public ActionResult GetUserTask(int userId)
        {
            var model = taskService
                .GetUserTasks(userId)
                .Select(x => x.ToViewTaskModel()).ToList();
            return PartialView("_GetUserTask",model);
        }
        public ActionResult GetAnswerUserTask(int userId)
        {
            var model = answerService.GetUsersSolvedAnswer(userId);
            return PartialView("_GetAnswerUserTask",model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}