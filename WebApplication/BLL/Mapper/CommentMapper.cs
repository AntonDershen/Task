using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
namespace BusinessLogic.Mapper
{
    public static class CommentMapper
    {
        public static CommentEntity ToCommentEntity(this Comment comment)
        {
            return new CommentEntity()
            {
                Id = comment.Id,
                Text = comment.Text,
                UserId = comment.UserId
            };
        }
        public static Comment ToComment(this CommentEntity commentEntity)
        {
            return new Comment()
            {
                Id = commentEntity.Id,
                Text = commentEntity.Text,
                UserId = commentEntity.UserId
            };
        }
    }
}
