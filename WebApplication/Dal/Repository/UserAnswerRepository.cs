using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.Repository;
using System.Data.Entity;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Repository
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private  DbContext context;
        public UserAnswerRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(int userId, int taskId, bool trueAnswer,bool firstAnswer)
        {
            context.Set<UserAnswers>().Add(new UserAnswers
            {
                TaskId = taskId,
                FirstAnswer = firstAnswer,
                Count = 1,
                TrueAnswer = trueAnswer,
                UserId = userId
            });
        }
        public IEnumerable<UserAnswers> FindUserAnswer(int taskId)
        {
            return context.Set<UserAnswers>().Where(x => x.TaskId == taskId).ToList();
        }
        public UserAnswers FindUserAnswer(int taskId, int userId)
        {
            return context.Set<UserAnswers>().Where(x => x.TaskId == taskId).FirstOrDefault(x => x.UserId == userId);
        }
        public void IncrementAnswerCount(int taskId, int userId)
        {
            using(var db = new EntityModel())
            {
                var userAnswer = db.UserAnswers.Where(x => x.TaskId == taskId)
                    .FirstOrDefault(x => x.UserId == userId);
                userAnswer.Count++;
                db.SaveChanges();
            }
        }
        public void UpdateTrueAnswer(int taskId, int userId)
        {
            using (var db = new EntityModel())
            {
                var userAnswer = db.UserAnswers.Where(x => x.TaskId == taskId)
                    .FirstOrDefault(x => x.UserId == userId);
                userAnswer.TrueAnswer = !userAnswer.TrueAnswer;
                db.SaveChanges();
            }
        }
        public IEnumerable<UserAnswers> FindUserAnswer(int userId, bool isSolved)
        {
            if (isSolved)
                return context.Set<UserAnswers>().Where(x => x.UserId == userId).Where(u => u.TrueAnswer).ToList();
            else return context.Set<UserAnswers>().Where(x => x.UserId == userId).ToList();

        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
