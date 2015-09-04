using BusinessLogic.Interface.Entities;
using WebApplication.Models;

namespace WebApplication.Infrastructure.Mappers
{
    public static class AuthorizationMapper
    {
        public static LoginModel ToLoginModel(this AuthorizationEntity authorisationEntity)
        {
            return new LoginModel()
            {
                Email = authorisationEntity.Email,
                Password = authorisationEntity.Password
            };
        }
        public static AuthorizationEntity ToAuthorizationEntity(this LoginModel loginModel)
        {
            return new AuthorizationEntity()
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };
        }
    }
}