using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Interface.Repository;
using System.Data.Entity;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private  DbContext context;
        public TaskRepository(DbContext context)
       {
  
            this.context = context;
       }
        public IEnumerable<Task> GetAll()
        {
            return context.Set<Task>().ToList();
        }
        public Task Find(int id)
        {
            return context.Set<Task>().Find(id);
        }
        public void Create(Task task)
        {
            throw new NotImplementedException();
        }
        public void Create(Task task,List<int> taskId,List<int> photosId)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var tagId in taskId)
                tags.Add(context.Set<Tag>().Find(tagId));
            List<Photo> photos = new List<Photo>();
            foreach (var photoId in photosId)
                photos.Add(context.Set<Photo>().Find(photoId));
            task.Tags = tags;
            task.Photos = photos;
            context.Set<Task>().Add(task);
        }
        public void Delete(Task task)
        {
            throw new NotImplementedException();
        }
        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
        public Task Get(Func<Task, Boolean> predicate)
        {
            return context.Set<Task>().FirstOrDefault(predicate);
        }
        public IEnumerable<Task> GetAll(Func<Task, Boolean> predicate,int begin,int count)
        {
            if (count == 0)
                return context.Set<Task>().Where(predicate).Where(X=>X.Activate == true);
            return context.Set<Task>().Where(predicate).Where(x=>x.Activate==true).Skip(begin).Take(count);
        }
        public int GetTaskCount()
        {
            try
            {
                var tasks =  context.Set<Task>().Where(x => x.Activate == true).ToList();
                return tasks.Count;
            }
            catch {return 0;}
        }
        public double GetRate(int taskId)
        {
            return context.Set<Task>().Find(taskId).Rate;
        }
        public void UpdateRate(int taskId, int rate,int userId)
        {
            using (var db = new EntityModel())
            {
                var task = db.Tasks.Find(taskId);
                task.Rate = (((task.Rate * task.RateCount) + rate) /( task.RateCount + 1));
                task.RateCount++;
                db.SaveChanges();
            }
            context.Set<Rate>().Add(new Rate()
                {
                    Rating = rate,
                    UserId = userId,
                    TaskId = taskId
                });
        }
        public Task GetMaxRate()
        {
            try
            {
                double rate = context.Set<Task>().Max(x => x.Rate);
                return context.Set<Task>().FirstOrDefault(x => x.Rate == rate);
            }
            catch
            {
                return null; 
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
