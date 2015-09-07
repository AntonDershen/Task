using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
namespace DataAccess.Mapper
{
    public static class CommentMapper
    {
        public static ORM.Сomment ToComment(this DataTransferComment dataTransferComment)
        {
            return new ORM.Сomment()
            {
                Id = dataTransferComment.Id,
                Text = dataTransferComment.Comment,
                UserId = dataTransferComment.UserId
            };
        }
        public static DataTransferComment ToDataTransferComment(this ORM.Сomment comment)
        {
            return new DataTransferComment()
            {
                Id = comment.Id,
                Comment = comment.Text,
                UserId = comment.UserId
            };
        }
    }
}
