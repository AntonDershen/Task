﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using WebApplication.Models;
using WebApplication.Filters;
using WebApplication.Infrastructure.Mappers;
using System.IO;
using System.Text;
namespace WebApplication.Controllers
{
    [Culture]
 
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IAuthorizationService authorizationService;
        private readonly ITagService tagService;
        private readonly IPhotoService photoService;
        private readonly IAnswerService answerService;
        private readonly IUserService userService;
           
        public TaskController(ITaskService taskService, IAuthorizationService authorizationService, ITagService tagService, IPhotoService photoService, IAnswerService answerService,IUserService userService)
        {
            this.taskService = taskService;
            this.authorizationService = authorizationService;
            this.tagService = tagService;
            this.photoService = photoService;
            this.answerService = answerService;
            this.userService = userService;
        }
           [Authorize]
        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }
           [Authorize]
        [HttpPost]
        public ActionResult CreateTask(CreateTaskModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var auth = authorizationService.Get(User.Identity.Name);
                int id = auth.UserId;
                List<int> photosId = new List<int>();
                if (file != null)
                {
                    byte[] fileContext = new byte[file.ContentLength];
                    file.InputStream.Read(fileContext, 0, file.ContentLength);
                    photosId.Add(photoService.CreatePhoto(fileContext));
                }
                taskService.CreateTask(model.ToTaskEntity(id, tagService.CreateTags(model.Tag).ToList(),photosId));
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
           [Authorize]
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
           [Authorize]
        public ActionResult ViewTask(int taskId)
        {
            ViewBag.Count = answerService.CountOfTrueAnswer(taskId);
            ViewBag.IsRate = answerService.IsRated(taskId, userService.GetUserId(User.Identity.Name));
            var task = taskService.Find(taskId);
            ViewBag.IsSolved = answerService.IsSolved(taskId, userService.GetUserId(User.Identity.Name));
            ViewBag.CreateUserId = task.CreateUserId;
            ViewBag.UserId = userService.GetUserId(User.Identity.Name);
            if (task.PhotoId.Count > 0)
            {
                List<byte> photo = photoService.FindPhoto(task.PhotoId[0]).ToList();
                ViewBag.Photo =string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(photo.ToArray()));
            }
            ViewBag.CreateUserName = userService.Find(userService.GetUserId(User.Identity.Name)).UserName;
            return View(task.ToViewTaskModel());
        }
           [Authorize]
        public ActionResult ViewTaskList(string categoryName)
        {
            ViewBag.Category = categoryName;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult ViewPartialTaskList(string categoryName,int begin,int count)
        {
            var taskViewModel = taskService.GetTaskList(categoryName, begin, count)
                .Select(x => x.ToViewTaskModel()).ToList();
            return PartialView("_ViewTaskList",taskViewModel);
        }
        [HttpPost]
        public ActionResult GetLastTask(int count,string category)
        {
            try
            {
                var tasks = taskService.GetLastTask(count,category).Select(x => x.ToViewTaskModel()).ToList();
                return PartialView("_GetLastTask", tasks);
            }
            catch
            {
                return PartialView("_GetLastTask", new List<ViewTaskModel>());
            }
        }
       [HttpPost]
       [Authorize]
        public ActionResult GetLastUserTask(int count)
        {
            try
            {
                int id = userService.GetUserId(User.Identity.Name);
                var lastTask = taskService.GetLastTask(count, id).Select(x => x.ToViewTaskModel()).ToList();
                return PartialView("_GetLastTask",lastTask);
            }
            catch
            {
                return PartialView("_GetLastTask", new List<ViewTaskModel>());
            }
        }
       [HttpPost]
       [Authorize]
       public void BlockTask(int taskId)
       {
           taskService.BlockTask(taskId);
       }
    }
}
