using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
namespace BusinessLogic.Interface.Services
{
    public interface IAnswerService
    {
       bool CheckAnswer(int taskId, string answer, int userId);
       bool IsSolved(int taskId, int userId);
       IEnumerable<AnswerEntity> GetUsersSolvedAnswer(int userId);
       bool IsRated(int taskId, int userId);
       int CountOfTrueAnswer(int taskId);
    }
}
