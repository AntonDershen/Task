using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface IUserAnswerRepository : IDisposable
    {
       void Create(int userId,int taskId,bool trueAnswer,bool firstAnswer);
       IEnumerable<UserAnswers> FindUserAnswer(int taskId);
       IEnumerable<UserAnswers> FindUserAnswer(int userId,bool isSolved);
       UserAnswers FindUserAnswer(int taskId, int userId);
       void IncrementAnswerCount(int taskId, int userId);
       void UpdateTrueAnswer(int taskId, int userId);


    }
}
