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
namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthorizationService authService;
        private readonly IAnswerService answerService;
        private readonly ITaskService taskService;
        public ClientController(IUserService userService, IAuthorizationService authService, IAnswerService answerService, ITaskService taskService)
        {
            this.userService = userService;
            this.authService = authService;
            this.answerService = answerService;
            this.taskService = taskService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("GetRandomTask");
            else
                return RedirectToAction("LogIn");

        }
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
                    return RedirectToAction("Index", "Client");
                }
                ModelState.AddModelError("", "");
            }
            return View(model);
        }

        public ActionResult GetRandomTask(int count=10)
        {
            var model = taskService.GetRandomTask(count,userService.GetUserId(User.Identity.Name))
                .Select(x=>x.ToViewTaskModel()).ToList();
            return View(model);
        }

        public ActionResult ViewTask(int taskId)
        {
            ViewBag.Count = answerService.CountOfTrueAnswer(taskId);
            ViewBag.IsRate = answerService.IsRated(taskId, userService.GetUserId(User.Identity.Name));
            var task = taskService.Find(taskId);
            ViewBag.IsSolved = answerService.IsSolved(taskId, userService.GetUserId(User.Identity.Name));
            ViewBag.CreateUserId = task.CreateUserId;
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            return View(task.ToViewTaskModel());
        }
        
    }
}