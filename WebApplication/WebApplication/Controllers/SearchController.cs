using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using WebApplication.Filters;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models;
namespace WebApplication.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITaskService taskService;

        public SearchController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        public ActionResult Search(string str)
        {
            try
            {
                var task = this.SearchTask(str).Select(x => x.ToViewTaskModel()).ToList();
                return View(task);
            }
            catch
            {
                return View(new List<ViewTaskModel>());
            }
        }
       
        private IEnumerable<TaskEntity> SearchTask(string str)
        {
            return  taskService.Search(str).Take(10).ToList();
        }
	}
}