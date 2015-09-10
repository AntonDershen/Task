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
                return unitOfWork.UserRepository.Get(x => x.UserName == user.UserName).Id;
            }
            return 0;
        }
        public void DeleteUser(UserEntity user)
        {
            unitOfWork.UserRepository.Delete(user.ToDataTransferUser());
            unitOfWork.Save();
        }
        public UserEntity Get(Func<UserEntity, Boolean> predicate) {
            return unitOfWork.UserRepository.GetAll().Select(x => x.ToUserEnity()).FirstOrDefault(predicate);
        }
        public IEnumerable<AuthorizationEntity> GetAuthorization(int id)
        {
            return unitOfWork.UserRepository.GetAuthorization(id).Select(x=>x.ToAuthorizationEntity());
        }
    }
}
