using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using WebApplication.Filters;
using WebApplication.Infrastructure.Mappers;
namespace WebApplication.Controllers
{
[Culture]
    public class RateController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;
        public RateController(IUserService userService, ITaskService taskService)
        {
            this.userService = userService;
            this.taskService = taskService;
        }
        [HttpPost]
        public void UpdateRate(int taskId,int rate)
        {
            taskService.UpdateRate(taskId, rate, userService.GetUserId(User.Identity.Name));
        }
        [HttpPost]
        public ActionResult GetRate(int taskId)
        {
            return PartialView("_TaskRate",taskService.GetRate(taskId));
        }
        [HttpPost]
        public ActionResult GetMaxRate()
        {
            return PartialView("_MaxRate",taskService.GetMaxRate().ToViewTaskModel());
        }
        [HttpPost]
        public ActionResult GetUserMaxRate()
        {
            int id = userService.GetUserId(User.Identity.Name);
            var taskUserMaxRate = taskService.GetMaxRate(id).ToViewTaskModel();
            return PartialView("_MaxRate", taskUserMaxRate);
        }
	}
}