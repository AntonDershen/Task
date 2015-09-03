using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataTransfer;
namespace BusinessLogic.Interfaces
{
    public interface IUserService : IDisposable
    {
        void CreateUser(UserDataTransfer userDataTransfer);
        UserDataTransfer GetUserDataTransfer(int id);
        IEnumerable<UserDataTransfer> GetAllUserDataTransfer();
    }
}
