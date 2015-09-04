using BusinessLogic.Interface.Entities;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserModel()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName
               
            };
        }
        public static UserEntity ToUserEntity(this UserModel userViewModel)
        {
            return new UserEntity()
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                RoleId =  1
            };
        }
    }
}