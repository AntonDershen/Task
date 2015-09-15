using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface IAnswerRepository :IDisposable
    {
       void CreateAnswer(string name,int taskId);
       bool CheckAnswer(int taskId, string name, int userId);
    }
}
