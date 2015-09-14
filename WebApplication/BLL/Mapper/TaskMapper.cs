using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
using BusinessLogic.Mapper;
namespace BusinessLogic.Mapper
{
    public static class TaskMapper
    {
        public static TaskEntity ToTaskEntity(this Task task)
        {
            try
            {
                return new TaskEntity()
                    {
                        Id = task.Id,
                        Complexity = task.Complexity,
                        Category = task.Category,
                        CreateUserId = task.UserId,
                        Name = task.Name,
                        TagsId = task.Tags.Select(x => x.Id).ToList(),
                        Condition = task.Condition,
                        Activate = task.Activate

                    };
            }
            catch
            {
                return null;
            }
        }
        public static Task ToTask(this TaskEntity taskEntity)
        {
            return new Task()
            {
                Id = taskEntity.Id,
                Complexity = taskEntity.Complexity,
                Category = taskEntity.Category,
                UserId = taskEntity.CreateUserId,
                Name = taskEntity.Name,
                Condition = taskEntity.Condition,
                Activate = taskEntity.Activate
            };
        }
    }
}
