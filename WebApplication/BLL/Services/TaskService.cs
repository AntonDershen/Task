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
            var achievement = unitOfWork.AchievementRepository.Get(taskEntity.CreateUserId);
            achievement.TaskCreated++;
            unitOfWork.AchievementRepository.Update(achievement);
            var tasks = unitOfWork.TaskRepository.GetAll(x => x.Condition == taskEntity.Condition,0,0);
            int id = tasks.LastOrDefault(x => x.UserId == taskEntity.CreateUserId).Id;
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
        public IEnumerable<TaskEntity> GetLastTask(int count, string category)
        {
            try
            {
                var tasks = unitOfWork.TaskRepository.GetAll(x => x.Category == category, 1, 0)
                    .Select(x => x.ToTaskEntity()).ToList();
                return tasks.Skip(tasks.Count - count).Take(count);
            }
            catch { return null; }
        }
        public IEnumerable<TaskEntity> GetLastTask(int count, int userId)
        {
            try
            {
                int taskCount = unitOfWork.TaskRepository.GetUserTaskCount(userId);
                return unitOfWork.TaskRepository.GetAll(x=>x.UserId == userId, taskCount - count, count)
                    .Select(x => x.ToTaskEntity()).ToList();
            }
            catch { return null; }
        }
        public void UpdateRate(int taskId, int rate,int userId)
        {
            unitOfWork.TaskRepository.UpdateRate(taskId, rate, userId);
            unitOfWork.Save();
        }
        public TaskEntity GetMaxRate()
        {
            return unitOfWork.TaskRepository.GetMaxRate().ToTaskEntity();
        }

        public TaskEntity GetMaxRate(int userId)
        {
            return unitOfWork.TaskRepository.GetUserMaxRate(userId).ToTaskEntity();
        }
        public double GetRate(int taskId)
        {
            return unitOfWork.TaskRepository.GetRate(taskId);
        }

        public IEnumerable<TaskEntity> Search(string input)
        {
            var searchResult = unitOfWork.TaskRepository.Search(input);
            if(searchResult!=null)
             return  searchResult.Select(x=>x.ToTaskEntity());
            return null;
        }
        public IEnumerable<TaskEntity> GetRandomTask(int count, int userId)
        {

            return unitOfWork.TaskRepository.GetRandomTask(count, userId).Select(x=>x.ToTaskEntity());
        }
        public IEnumerable<TaskEntity> GetUserTasks(int userId)
        {
            return unitOfWork.TaskRepository.GetAll(x => x.UserId == userId, 0, 0).Select(x => x.ToTaskEntity()).ToList();
        }
        public void BlockTask(int taskId)
        {
            unitOfWork.TaskRepository.BlockTask(taskId);

        }
    }
}
