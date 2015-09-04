using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.Interface.Entities;
using WebApplication.Models;
namespace WebApplication.Infrastructure.Mappers
{
    public static class RegisterMapper
    {
        public static UserEntity ToUserEntity(this RegisterModel registerModel)
        {
            return new UserEntity
            {
                UserName = registerModel.UserName
            };
        }
        public static AuthorizationEntity ToAuthorizationEntity(this RegisterModel registerModel,int userId=0)
        {
            return new AuthorizationEntity
            {
                Email = registerModel.Email,
                Password = registerModel.Password,
                UserId = userId
            };
        
        }
    }
}