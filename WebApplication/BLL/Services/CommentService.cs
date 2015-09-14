using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.Repository;
using BusinessLogic.Mapper;
using BusinessLogic.Interface.Services;
namespace BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Creat(CommentEntity commentEntity)
        {
            unitOfWork.CommentRepository.CreateComment(commentEntity.ToComment());
            unitOfWork.Save();
        }
        public IEnumerable<CommentEntity> GetUserComment(int userId)
        {
            return unitOfWork.CommentRepository.Get(x => x.UserId == userId).Select(x => x.ToCommentEntity()).ToList();
        }
        public IEnumerable<CommentEntity> GetTaskComment(int taskId)
        {
            return unitOfWork.CommentRepository.Get(x => x.TaskId == taskId).Select(x => x.ToCommentEntity()).ToList();
    
        }
    }
}
