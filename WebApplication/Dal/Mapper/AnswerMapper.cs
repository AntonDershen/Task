using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
using ORM;
namespace DataAccess.Mapper
{
    public static class AnswerMapper
    {
        public static Answer ToAnswer(this DataTransferAnswer dataTransferAnswer)
        {
            return new Answer()
            {
                Id = dataTransferAnswer.Id,
                TaskId = dataTransferAnswer.TaskId,
                Name = dataTransferAnswer.Name
            };
        }
        public static DataTransferAnswer ToDataTransferAnswer(this Answer answer)
        {
            return new DataTransferAnswer()
            {
                Id = answer.Id,
                TaskId = answer.TaskId,
                Name = answer.Name
            };
        }
    }
}
