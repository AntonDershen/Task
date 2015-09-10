using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface.Services
{
    public interface IPhotoService
    {
         string CreatePhoto(byte[] photo);
    }
}
