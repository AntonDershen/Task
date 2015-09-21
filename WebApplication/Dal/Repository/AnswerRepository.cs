using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Interface.Repository;
using DataAccess.Repository;
using DataAccess.Interface.EntityFramework;
using System.Data.Entity;
namespace DataAccess.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private  DbContext context;
        public AnswerRepository(DbContext context)
        {
            this.context = context;
        }
        public void CreateAnswer(string text, int taskId)
        {
            text = text.ToLower();
            context.Set<Answer>().Add(new Answer(){
                TaskId = taskId,
                Text = text
            });
        }
      
        public bool CheckAnswer(int taskId, string name, int userId)
        {
            name = name.ToLower();
            Task task = context.Set<Task>().Find(taskId);
            if(task.Answers.FirstOrDefault(X=>X.Text == name) != null )
                return true;
            return false;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
