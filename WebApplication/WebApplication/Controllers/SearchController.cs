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
            return View(str);
        }
        [HttpPost]
        public ActionResult SearhTask(string str)
        {
            var searchResults = taskService.Search(str);
            if(searchResults!=null)
                return PartialView("_SearchTask",searchResults.Select(x=>x.ToViewTaskModel()).ToList());
            return PartialView("_SearchTask", new List<ViewTaskModel>());
        }
	}
}