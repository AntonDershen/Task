using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using WebApplication.Infrastructure.Mappers;
namespace WebApplication.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IUserService userService;
        public CommentController(IUserService userService,ICommentService commentService)
        {
            this.userService = userService;
            this.commentService = commentService;
        }
        [HttpPost]
        public bool CreateComment(int taskId,string text)
        {
            commentService.Creat(new CommentEntity()
            {
                TaskId = taskId,
                Text = text,
                Time = DateTime.UtcNow,
                UserId = userService.GetUserId(User.Identity.Name)
            });
            return true;
        }
        [HttpPost]
        public ActionResult GetTaskComment(int taskId)
        {
            var model = commentService.GetTaskComment(taskId);
            var viewModel = model.Select(x => x.ToCommentViewModel(userService.Find(x.UserId).UserName));
            return PartialView("CommentView",viewModel);
        }
	}
}