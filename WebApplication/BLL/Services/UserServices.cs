using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interface.Repository;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
using BusinessLogic.Mapper;
using System.IO;
using System.Web.Security;
namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return unitOfWork.UserRepository.GetAll().Select(x=>x.ToUserEnity());
        }
        public UserEntity Find(int id)
        {
            return unitOfWork.UserRepository.Find(id).ToUserEnity();

        }
        public int CreateUser(UserEntity user,string email)
        {
            if (unitOfWork.AuthorizationRepository.Get(x=>x.Email == email) == null)
            {
                unitOfWork.UserRepository.Create(user.ToDataTransferUser());
                unitOfWork.Save();
                var userId = unitOfWork.UserRepository.Get(x => x.UserName == user.UserName).Id;
                unitOfWork.AchievementRepository.Create(userId);
                return userId;
            }
            return 0;
        }
        public void DeleteUser(UserEntity user)
        {
            unitOfWork.UserRepository.Delete(user.ToDataTransferUser());
            unitOfWork.Save();
        }
        public IEnumerable<AuthorizationEntity> GetAuthorization(int id)
        {
            return unitOfWork.UserRepository.GetAuthorization(id).Select(x=>x.ToAuthorizationEntity());
        }
        public int GetUserId(string email)
        {
            return unitOfWork.UserRepository.Get(x => x.Authorizations.ToList()[0].Email == email).Id;
        }
        public List<int> GetUserAchivement(int userId)
        {
            var achivement = unitOfWork.AchievementRepository.Get(userId);
            List<int> achivementLevel = new List<int>();
            if (achivement.TaskCreated == 0)
                achivementLevel.Add(0);
            else achivementLevel.Add((int)(Math.Log(achivement.TaskCreated, 2)));
            if (achivement.TaskAnswered == 0)
                achivementLevel.Add(0);
            else achivementLevel.Add((int)(Math.Log(achivement.TaskAnswered, 2)));
            if (achivement.FirstAnswered == 0)
                achivementLevel.Add(0);
            else achivementLevel.Add((int)(Math.Log(achivement.FirstAnswered, 2)));
            return achivementLevel;
        }
    }
}
