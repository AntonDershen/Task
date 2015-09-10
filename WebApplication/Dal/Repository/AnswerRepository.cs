using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            context.Set<Answer>().Add(new Answer(){
                TaskId = taskId,
                Text = text
            });
        }
    }
}
