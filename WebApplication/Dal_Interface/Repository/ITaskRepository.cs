﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        void Create(Task task, List<int> tagsId,List<int> photoId);
        int GetTaskCount();
        int GetUserTaskCount(int userId);
        double GetRate(int taskId);
        Task GetMaxRate();
        Task GetUserMaxRate(int userId);
        void UpdateRate(int taskId,int rate,int userId);
    }
}
