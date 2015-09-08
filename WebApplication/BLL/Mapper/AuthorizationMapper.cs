using System;
using System.Collections.Generic;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
namespace BusinessLogic.Mapper
{
    public static  class AuthorizationMapper
    {
        public static Authorization ToAuthorization(this AuthorizationEntity authorisationEntity)
        {
            return new Authorization()
            {
                Id = authorisationEntity.Id,
                Email = authorisationEntity.Email,
                Password = authorisationEntity.Password,
                UserId = authorisationEntity.UserId,
                Confirm = authorisationEntity.Confirm
            };
        }
        public static AuthorizationEntity ToAuthorizationEntity(this Authorization authorization)
        {
            return new AuthorizationEntity()
            {
                Id = authorization.Id,
                Email = authorization.Email,
                Password = authorization.Password,
                UserId = authorization.UserId,
                Confirm = authorization.Confirm
            };
        }
    }
}
