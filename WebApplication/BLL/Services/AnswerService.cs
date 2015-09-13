using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.Repository;
using DataAccess.Interface.EntityFramework;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using BusinessLogic.Mapper;
namespace BusinessLogic.Services
{
    public class AnswerService : IAnswerService
    {  
        private readonly IUnitOfWork unitOfWork;
        public AnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public bool CheckAnswer(int taskId, string answer, int userId)
        {
            if( unitOfWork.AnswerRepository.CheckAnswer(taskId, answer, userId))
            {
                bool firstAnswer = false;
                if (unitOfWork.UserAnswerRepository.FindUserAnswer(taskId) == null)
                    firstAnswer = true;
                if (unitOfWork.UserAnswerRepository.FindUserAnswer(taskId, userId) == null)
                {
                    unitOfWork.UserAnswerRepository.Create(userId, taskId, true, firstAnswer);
                    unitOfWork.UserRepository.UpdateRate(unitOfWork.TaskRepository.Find(taskId).Complexity, userId);
                    unitOfWork.Save();
                }
                else
                {
                    unitOfWork.UserAnswerRepository.IncrementAnswerCount(taskId,userId);
                    unitOfWork.UserAnswerRepository.UpdateTrueAnswer(taskId, userId);
                    unitOfWork.UserRepository.UpdateRate(unitOfWork.TaskRepository.Find(taskId).Complexity, userId);
                }
                return true;
            }
            if (unitOfWork.UserAnswerRepository.FindUserAnswer(taskId, userId) == null)
            {
                unitOfWork.UserAnswerRepository.Create(userId, taskId, false, false);
                unitOfWork.Save();
            }
            else
            {
                unitOfWork.UserAnswerRepository.IncrementAnswerCount(taskId, userId);
            }
            return false;
        }
        public bool IsSolved(int taskId, int userId)
        {
            var userAnswer = unitOfWork.UserAnswerRepository.FindUserAnswer(taskId, userId);
            if (userAnswer == null)
                return false;
            else return userAnswer.TrueAnswer;

        }
    }
}
