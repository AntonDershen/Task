using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.Repository;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface IPhotoRepository
    {
        void CreatePhoto(byte[] photo);
        Photo Get(Func<Photo, bool> predicate);
    }
}
