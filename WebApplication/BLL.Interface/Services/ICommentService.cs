using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
namespace BusinessLogic.Interface.Services
{
    public interface ICommentService
    {
        void Creat(CommentEntity commentEntity);
        IEnumerable<CommentEntity> GetUserComment(int userId);
        IEnumerable<CommentEntity> GetTaskComment(int commentId);
    }
}
