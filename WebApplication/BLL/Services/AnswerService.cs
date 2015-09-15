﻿using System;
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
            if (userAnswer == null || userAnswer.UserId == userId)
                return false;
            else return userAnswer.TrueAnswer;

        }
        public IEnumerable<AnswerEntity> GetUsersSolvedAnswer(int userId)
        {
            var answers = unitOfWork.UserAnswerRepository.FindUserAnswer(userId, true).Select(x=>x.ToAnswerEntity()).ToList();
            for (int i = 0; i < answers.Count; i++)
                answers[i].Name = unitOfWork.TaskRepository.Find(answers[i].TaskId).Name;
            return answers;
        }
        public bool IsRated(int taskId, int userId)
        {
            var userAnswers = unitOfWork.UserAnswerRepository.FindUserAnswer(taskId).ToList();
            foreach (var userAnswer in userAnswers)
                if (userAnswer.UserId == userId)
                    return false;
            var task = unitOfWork.TaskRepository.Find(taskId);
            if (task.UserId == userId)
                return false;
            return true;
        }
        public int CountOfTrueAnswer(int taskId)
        {
            return unitOfWork.UserAnswerRepository.FindUserAnswer(taskId).Where(x => x.TrueAnswer).ToList().Count;
        }
    }
}
