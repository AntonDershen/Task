using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
namespace DataAccess.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DataTransferUser> UserRepository { get; }
        IRepository<DataTransferAuthorization> AuthorizationRepository { get; }
        void Save();
    }
}
