using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
using ORM;
namespace DataAccess.Mapper
{
    public static class TaskMapper
    {
        public static ORM.Task ToTask(DataTransferTask dataTransferTask)
        {
            return new ORM.Task(){
                Id = dataTransferTask.Id,
                Answers = dataTransferTask.Answers.Select(x=>x.ToAnswer()).ToList(),
                Comments = dataTransferTask.Comments.Select(x=>x.ToComment()).ToList(),
                Complexity = dataTransferTask.Complexity,
                Category = dataTransferTask.Category,
                CreateUserId = dataTransferTask.CreateUserId,
                Name = dataTransferTask.Name,
                Users = dataTransferTask.Users.Select(x=>x.ToUser()).ToList(),
                Tags = dataTransferTask.Tags.Select(x=>x.ToTag()).ToList()               
            };
        }
        public static DataTransferTask ToDataTransferTask(ORM.Task task)
        {
            return new DataTransferTask()
            {
                Id = task.Id,
                Complexity = task.Complexity,
                Category = task.Category,
                CreateUserId = task.CreateUserId,
                Name = task.Name,
                Users = task.Users.Select(x=>x.ToDataTransferUser()).ToList(),
                Answers = task.Answers.Select(x=>x.ToDataTransferAnswer()).ToList(),
                Comments = task.Comments.Select(x=>x.ToDataTransferComment()).ToList(),
                Rate = RateMapper.CalculateRate(task.Rates),
                Tags = task.Tags.Select(x=>x.ToDataTransferTag()).ToList()
            };
        }


     
    }
}
