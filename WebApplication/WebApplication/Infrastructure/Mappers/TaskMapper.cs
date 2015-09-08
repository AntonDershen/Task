using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Infrastructure.Mappers
{
    public static class TaskMapper
    {
        public static TaskEntity ToTaskEntity(this CreateTaskModel taskModel,int userId,List<int> tagsId)
        {
            return new TaskEntity()
            {
                Id = taskModel.Id,
                Complexity = taskModel.Complexity,
                Category = taskModel.Category,
                CreateUserId = userId,
                Name =taskModel.Name,
                Condition = taskModel.Condition,
                TagsId = tagsId,
                Answers = taskModel.Answers
            };
        }
    }
}