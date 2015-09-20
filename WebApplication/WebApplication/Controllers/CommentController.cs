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
        public CommentController(IUserService userService, ICommentService commentService)
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
        public ActionResult GetComment(int taskId, int begin,int count)
        {
            var comments = commentService.GetTaskComment(taskId).ToList();
            if (comments.Count < begin)
                return PartialView("_Comment", new List<WebApplication.Models.CommentViewModel>());
            if(comments.Count > (begin+count))
             return PartialView("_Comment",comments.Skip(begin).Take(count).ToList());
            return PartialView("_Comment", comments.Skip(begin).Take(comments.Count - begin).ToList());
        }
	}
}