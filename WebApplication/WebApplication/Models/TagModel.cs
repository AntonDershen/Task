﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.App_LocalResources;
using WebApplication.Filters;

namespace WebApplication.Models
{
    [Culture]
    public class TagModel
    {
        public int Id;
        [Display(ResourceType = typeof(GlobalRes), Name = "Text")]     
        public string Text { get; set; }
    }
}