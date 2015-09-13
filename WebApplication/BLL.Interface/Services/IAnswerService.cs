using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLogic.Interface.Services
{
    public interface IAnswerService
    {
       bool CheckAnswer(int taskId, string answer, int userId);
       bool IsSolved(int taskId, int userId);
    }
}
