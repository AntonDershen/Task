using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;

namespace BusinessLogic.Interface.Services
{
    public interface IAuthorizationService
    {
        void CreateAuthorization(AuthorizationEntity authorization);
        void UpdateAuthorization(AuthorizationEntity authorization);
        void DeleteAuthorization(AuthorizationEntity authorization);
        AuthorizationEntity Find(int id);
        bool CheckForm(AuthorizationEntity authorization);
        AuthorizationEntity Get(Func<AuthorizationEntity, bool> predicate);
    }
}
