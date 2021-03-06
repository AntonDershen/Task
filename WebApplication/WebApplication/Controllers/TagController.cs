﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interface.Services;
using WebApplication.Models;
using WebApplication.Infrastructure.Mappers;
using System.IO;
namespace WebApplication.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        [HttpPost]
        public string GetTags(string data)
        {
            List<string> tags = tagService.GetTags(data).ToList();
            string tagsToAjax = string.Empty;
            foreach (var tag in tags)
                tagsToAjax += tag + "#";
            return tagsToAjax;
        }
        [HttpPost]
        public ActionResult GetRandomTags(int count)
        {
            List<string> model = new List<string>();
            try
            {
                model = tagService.GetRandomTags(count).ToList();
                Random random = new Random();
                List<int> rel = new List<int>();
                for (int i = 0; i < model.Count; i++)
                    rel.Add((int)(random.NextDouble() * 10));
                ViewBag.Rel = rel;
                return PartialView("_GetRandomTags", model);
            }
            catch {
                return PartialView("_GetRandomTags", model);
            }
        }
        [HttpPost]
        public ActionResult GetTagsById(string  tagsStringId,char splitElement)
        {
            List<int> tagsId = tagsStringId.Split(splitElement).Select(x => Int32.Parse(x)).ToList();
            List<string> tagsName = new List<string>();
            foreach (var tagId in tagsId)
                tagsName.Add(tagService.GetTag(tagId));
            ViewBag.Name = tagsName;
            return PartialView("_TaskTagView");
        }
	}
}