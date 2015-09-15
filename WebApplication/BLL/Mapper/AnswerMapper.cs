using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
namespace BusinessLogic.Mapper
{
    public static class AnswerMapper
    {
        public static AnswerEntity ToAnswerEntity(this UserAnswers userAnswer)
        {
            return new AnswerEntity()
            {
                Id = userAnswer.Id,
                IsSolved = userAnswer.TrueAnswer,
                Count = userAnswer.Count,
                TaskId = userAnswer.TaskId
            };
        }
    }
}
