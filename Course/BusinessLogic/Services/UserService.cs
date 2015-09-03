using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using BusinessLogic.DataTransfer;
using BusinessLogic.Mapper;
namespace BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork { get; set; }
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<UserDataTransfer> GetAllUserDataTransfer()
        {
            return unitOfWork.UserRepository.GetAll().Select(x => x.ToUserDataTransfer());
        }
        public void CreateUser(UserDataTransfer userDataTransfer)
        {
            unitOfWork.UserRepository.Create(userDataTransfer.ToUser());
        }
        public UserDataTransfer GetUserDataTransfer(int id)
        {
            return unitOfWork.UserRepository.Find(id).ToUserDataTransfer();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
