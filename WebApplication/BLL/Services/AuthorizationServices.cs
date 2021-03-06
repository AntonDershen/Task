﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interface.Repository;
using DataAccess.Interface.EntityFramework;
using BusinessLogic.Interface.Services;
using BusinessLogic.Interface.Entities;
using BusinessLogic.Mapper;

namespace BusinessLogic.Services
{
    public class AuthorizationServices:IAuthorizationService
    {
        private readonly IUnitOfWork unitOfWork;
        public AuthorizationServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public AuthorizationEntity Find(int id)
        {
            return unitOfWork.AuthorizationRepository.Find(id).ToAuthorizationEntity();
        }
        public void CreateAuthorization(AuthorizationEntity authorizationEntity)
        {
            unitOfWork.AuthorizationRepository.Create(authorizationEntity.ToAuthorization());
            unitOfWork.Save();
        }
        public void UpdateAuthorization(AuthorizationEntity authorizationEntity)
        {
            unitOfWork.AuthorizationRepository.Update(authorizationEntity.ToAuthorization());
         
        }
        public void DeleteAuthorization(AuthorizationEntity authorizationEntity)
        {
            unitOfWork.AuthorizationRepository.Delete(authorizationEntity.ToAuthorization());
            unitOfWork.Save();
        }
        public bool CheckForm(AuthorizationEntity authorization)
        {
            var auth = unitOfWork.AuthorizationRepository.Get(x => x.Email == authorization.Email);
            if (auth != null && auth.Password == authorization.Password && auth.Confirm == true)
                return true;
            return false;
        }
        public AuthorizationEntity Get(string email)
        {
            return unitOfWork.AuthorizationRepository.Get(x => x.Email == email).ToAuthorizationEntity();

            
        }
    }
}
