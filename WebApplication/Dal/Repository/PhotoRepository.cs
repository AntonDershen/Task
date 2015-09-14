using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
using DataAccess.Interface.Repository;
using System.Data.Entity;
namespace DataAccess.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private  DbContext context;
        public PhotoRepository(DbContext context)
        {
            this.context = context;
        }
        public void CreatePhoto(byte[] photo)
        {
            context.Set<Photo>().Add(new Photo(){
               Context =  photo
            });
        }
        public Photo Get(Func<Photo,bool> predicate)
        {
            return context.Set<Photo>().FirstOrDefault(predicate);
        }
        public Photo Find(int id)
        {
            return context.Set<Photo>().Find(id);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
