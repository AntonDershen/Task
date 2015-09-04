using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
using ORM;
namespace Dal.Mapper
{
    public static class UserMapper
    {
        public static DataTransferUser ToDataTransferUser(this User user)
        {
            if (user != null)
            {
                return new DataTransferUser()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            return null;
        }
        public static User ToUser(this DataTransferUser dataTranferUser)
        {
            if (dataTranferUser != null)
            {
                return new User()
                {
                    Id = dataTranferUser.Id,
                    UserName = dataTranferUser.UserName
                };
            }
            return null;
        }

    }
}