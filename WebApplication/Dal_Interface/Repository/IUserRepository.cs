using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<Authorization> GetAuthorization(int id);
    }
}
