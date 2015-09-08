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
        public void Create(Task task,List<int> tagsId)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var tagId in tagsId)
                tags.Add(context.Set<Tag>().Find(tagId));
            task.Tags = tags;
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
        public IEnumerable<Task> GetAll(Func<Task, Boolean> predicate)
        {
            return context.Set<Task>().Where(predicate);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
