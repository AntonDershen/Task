using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataTransfer;
using DataAccess.Entities;
namespace BusinessLogic.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(this UserDataTransfer userDataTransfer)
        {
            return new User()
            {
                Id = userDataTransfer.Id,
                UserName = userDataTransfer.UserName
            };
        }
        public static UserDataTransfer ToUserDataTransfer(this User user)
        {
            return new UserDataTransfer()
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }
    }
}
