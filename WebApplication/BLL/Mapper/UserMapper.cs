using System;
using System.Collections.Generic;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.DataTransfer;
namespace BusinessLogic.Mapper
{
    public static class BllEntityMappers
    {
        public static DataTransferUser ToDataTransferUser(this UserEntity userEntity)
        {
            return new DataTransferUser()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName
            };
        }
        public static UserEntity ToUserEnity(this DataTransferUser dataTransferUser)
        {
            return new UserEntity()
            {
                Id = dataTransferUser.Id,
                UserName = dataTransferUser.UserName
            };
        }
    }
}
