using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using WebApplication.Models;
using WebApplication.Infrastructure.Mappers;
namespace WebApplication.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IAuthorizationService authorizationService;
        private readonly ITagService tagService;
        public TaskController(ITaskService taskService, IAuthorizationService authorizationService, ITagService tagService)
        {
            this.taskService = taskService;
            this.authorizationService = authorizationService;
            this.tagService = tagService;
        }
        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTask(CreateTaskModel model)
        {
            if (ModelState.IsValid)
            {
                var auth = authorizationService.Get(x => x.Email == User.Identity.Name);
                int id = auth.UserId;
                taskService.CreateTask(model.ToTaskEntity(id,tagService.CreateTags(model.Tag).ToList()));
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public string GetTags(string tagName)
        {
            List<string> tags = tagService.GetTags(tagName).ToList();
            string tagsToAjax = string.Empty;
            foreach (var tag in tags)
                tagsToAjax += tag + "#";
            return tagsToAjax;
        }
	}
}