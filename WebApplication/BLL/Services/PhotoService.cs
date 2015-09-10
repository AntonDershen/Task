using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Services;
using DataAccess.Interface.Repository;
namespace BusinessLogic.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        public PhotoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int CreatePhoto(byte[] photo)
        {
            unitOfWork.PhotoRepository.CreatePhoto(photo);
            unitOfWork.Save();
            return unitOfWork.PhotoRepository.Get(x => x.Context == photo).Id;
        }
    }
}
