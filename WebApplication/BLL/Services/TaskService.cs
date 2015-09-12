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
            var tasks = unitOfWork.TaskRepository.GetAll(x => x.Condition == taskEntity.Condition,0,0);
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
        public IEnumerable<TaskEntity> GetTaskList(string tagName, int begin, int count)
        {
           var tasks =  unitOfWork.TaskRepository
               .GetAll(x => x.Tags.FirstOrDefault(u=>u.Name == tagName) != null, begin, count)
               .Select(x=>x.ToTaskEntity())
               .ToList();
           return tasks;
        }
        public IEnumerable<TaskEntity> GetLastTask(int count)
        {
            int taskCount = unitOfWork.TaskRepository.GetTaskCount();
            return unitOfWork.TaskRepository.GetAll(x=>x.Id>0, taskCount - count, count)
                .Select(x=>x.ToTaskEntity()).ToList();
        }
        public IEnumerable<TaskEntity> CheckAnswer(int userId, int taskId, string answer)
        {
            throw new NotImplementedException();

        }
    }
}
