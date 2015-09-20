using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface.Services
{
    public interface IPhotoService
    {
         int CreatePhoto(byte[] photo);
         byte[] FindPhoto(int photoId);
    }
}
