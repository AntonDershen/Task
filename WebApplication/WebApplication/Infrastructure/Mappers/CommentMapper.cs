using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Infrastructure.Mappers
{
    public static class CommentMapper
    {
        public static CommentViewModel ToCommentViewModel(this CommentEntity commentEntity,string userName)
        {
            return new CommentViewModel()
            {
                UserId = commentEntity.UserId,
                Text = commentEntity.Text,
                Time = commentEntity.Time,
                UserName = userName
            };
        }
    }
}