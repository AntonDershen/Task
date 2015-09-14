using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CommentViewModel
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}