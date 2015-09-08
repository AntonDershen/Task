using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
namespace BusinessLogic.Interface.Services
{
    public interface ITaskService
    {
        void CreateTask(TaskEntity task);
        TaskEntity Find(int id);
        TaskEntity Get(Func<TaskEntity, bool> predicate);
    }
}
