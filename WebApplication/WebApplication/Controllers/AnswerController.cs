using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Filters;
using System.Web.Security;
using System.Net.Mail;

namespace WebApplication.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IAnswerService answerService;
        private readonly IUserService userService;
        public AnswerController(IAnswerService answerService, IUserService userService)
        {
            this.answerService = answerService;
            this.userService = userService;
        }
        [HttpPost]
        public bool CheckAnswer(int taskId , string answer)
        {
            return answerService.CheckAnswer(taskId, answer, userService.GetUserId(User.Identity.Name));   
        }
	}
}