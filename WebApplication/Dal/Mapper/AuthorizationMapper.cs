using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
using ORM;
namespace DataAccess.Mapper
{
    public static class AuthorizationMapper
    {
        public static DataTransferAuthorization ToDataTransferAuthorization(this Authorization authorization)
        {
            if (authorization != null)
            {
                return new DataTransferAuthorization()
                {
                    Id = authorization.Id,
                    Email = authorization.Email,
                    Password = authorization.Password,
                    UserId = authorization.UserId,
                    Confrim = authorization.Confirm
                };
            }
            return null;
        
        }
        public static Authorization ToAuthorization(this DataTransferAuthorization dataTransferAuthorization)
        {

            if (dataTransferAuthorization != null)
            {
                return new Authorization()
                {
                    Id = dataTransferAuthorization.Id,
                    Email = dataTransferAuthorization.Email,
                    Password = dataTransferAuthorization.Password,
                    UserId = dataTransferAuthorization.UserId,
                    Confirm = dataTransferAuthorization.Confrim
                };
            }
            return null;
        }

    }
}
