using System;
using System.Collections.Generic;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
namespace BusinessLogic.Mapper
{
    public static class BllEntityMappers
    {
        public static User ToDataTransferUser(this UserEntity userEntity)
        {
            return new User()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName
            };
        }
        public static UserEntity ToUserEnity(this User dataTransferUser)
        {
            return new UserEntity()
            {
                Id = dataTransferUser.Id,
                UserName = dataTransferUser.UserName
            };
        }
    }
}
