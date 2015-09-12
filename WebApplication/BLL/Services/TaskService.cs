using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Services;
using DataAccess.Interface.Repository;
using BusinessLogic.Interface.Entities;
using BusinessLogic.Mapper;
namespace BusinessLogic.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void CreateTask(TaskEntity taskEntity)
        {
            taskEntity.Activate = true;
            unitOfWork.TaskRepository.Create(taskEntity.ToTask(),taskEntity.TagsId,taskEntity.PhotoId);
            unitOfWork.Save();
            var tasks = unitOfWork.TaskRepository.GetAll(x => x.Condition == taskEntity.Condition);
            int id = tasks.LastOrDefault(x => x.CreateUserId == taskEntity.CreateUserId).Id;
            foreach (var answer in taskEntity.Answers)
            {
                unitOfWork.AnswerRepository.CreateAnswer(answer, id);
                unitOfWork.Save();
            }
        }
        public TaskEntity Find(int id)
        {
            return unitOfWork.TaskRepository.Find(id).ToTaskEntity();
        }
        public TaskEntity Get(Func<TaskEntity, bool> predicate)
        {
            return unitOfWork.TaskRepository.GetAll().Select(x => x.ToTaskEntity()).FirstOrDefault(predicate);
        }
    }
}
