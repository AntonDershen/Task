using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using WebApplication.Models;
using WebApplication.Filters;
using WebApplication.Infrastructure.Mappers;
using System.IO;

namespace WebApplication.Controllers
{
    [Culture]
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IAuthorizationService authorizationService;
        private readonly ITagService tagService;
        private readonly IPhotoService photoService;
        public TaskController(ITaskService taskService, IAuthorizationService authorizationService, ITagService tagService, IPhotoService photoService)
        {
            this.taskService = taskService;
            this.authorizationService = authorizationService;
            this.tagService = tagService;
            this.photoService = photoService;
        }
        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTask(CreateTaskModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var auth = authorizationService.Get(User.Identity.Name);
                int id = auth.UserId;
                byte[] fileContext = new byte[file.ContentLength];
                file.InputStream.Read(fileContext,0,file.ContentLength);
                List<int> photosId = new List<int>();
                photosId.Add(photoService.CreatePhoto(fileContext));
                taskService.CreateTask(model.ToTaskEntity(id, tagService.CreateTags(model.Tag).ToList(),photosId));
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public void Upload()
        {
            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);
            var fileSize = Int32.Parse(Request.Headers["X-File-Size"]);
            var byteList = bytes.ToList();
            byteList = byteList.Skip(bytes.Length - fileSize - 46).ToList();
            photoService.CreatePhoto(byteList.Take(fileSize).ToArray());
        }
        public ActionResult ViewTask(int taskId)
        {
            var task = taskService.Find(taskId).ToViewTaskModel();
            return View(task);
        }
        public ActionResult ViewTaskList(string categoryName)
        {
            ViewBag.Category = categoryName;
            return View();
        }
        [HttpPost]
        public ActionResult ViewPartialTaskList(string categoryName,int begin,int count)
        {
            var taskViewModel = taskService.GetTaskList(categoryName, begin, count)
                .Select(x => x.ToViewTaskModel()).ToList();
            return PartialView("_ViewTaskList",taskViewModel);
        }
        [HttpPost]
        public ActionResult GetLastTask(int count)
        {
            return PartialView("_GetLastTask",taskService.GetLastTask(count).Select(x=>x.ToViewTaskModel()).ToList());
        }
    }
}
