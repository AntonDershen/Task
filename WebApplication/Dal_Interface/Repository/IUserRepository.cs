using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
namespace DataAccess.Interface.Repository
{
    public interface IUserRepository : IRepository<DataTransferUser>
    {
        IEnumerable<DataTransferAuthorization> GetAuthorization(int id);
    }
}
