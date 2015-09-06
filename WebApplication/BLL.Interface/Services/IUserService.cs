using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
namespace BusinessLogic.Interface.Services
{
    public interface IUserService
    {
        int CreateUser(UserEntity user,string email);
        void DeleteUser(UserEntity user);
        UserEntity Find(int id);
        UserEntity Get(Func<UserEntity,bool> predicate);
        IEnumerable<AuthorizationEntity> GetAuthorization(int id);
    }
}
