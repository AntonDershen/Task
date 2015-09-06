using System;
using System.Collections.Generic;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.DataTransfer;
namespace BusinessLogic.Mapper
{
    public static  class AuthorizationMapper
    {
        public static DataTransferAuthorization ToDataTransferAuthorization(this AuthorizationEntity authorisationEntity)
        {
            return new DataTransferAuthorization()
            {
                Id = authorisationEntity.Id,
                Email = authorisationEntity.Email,
                Password = authorisationEntity.Password,
                UserId = authorisationEntity.UserId,
                Confrim = authorisationEntity.Confirm
                
            };
        }
        public static AuthorizationEntity ToAuthorizationEntity(this DataTransferAuthorization dataTransferAuthorization)
        {
            return new AuthorizationEntity()
            {
                Id = dataTransferAuthorization.Id,
                Email = dataTransferAuthorization.Email,
                Password = dataTransferAuthorization.Password,
                UserId = dataTransferAuthorization.UserId,
                Confirm = dataTransferAuthorization.Confrim
            };
        }
    }
}
