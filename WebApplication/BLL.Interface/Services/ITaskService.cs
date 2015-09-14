﻿using System;
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
        IEnumerable<TaskEntity> GetTaskList(string categoryName,int begin,int count);
        IEnumerable<TaskEntity> GetLastTask(int count);
        void UpdateRate(int taskId, int rate,int userId);
        TaskEntity GetMaxRate();
        double GetRate(int taskId);
    }
}
