using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.Repository;
using DataAccess.Interface.DataTransfer;
using System.Data.Entity;
using ORM;
using DataAccess.Mapper;
namespace DataAccess.Repository
{
    public class AuthorizationRepository : IRepository<DataTransferAuthorization>
    {
        private  DbContext context;
        public AuthorizationRepository(DbContext context)
        {
  
            this.context = context;
        }
        public DataTransferAuthorization Find(int id)
        {
            return context.Set<Authorization>().Find(id).ToDataTransferAuthorization();
        }
        public IEnumerable<DataTransferAuthorization> GetAll()
        {
            return context.Set<Authorization>().ToList().Select(user => user.ToDataTransferAuthorization());
        }
        public void Create(DataTransferAuthorization dataTransferAuthorization)
        {
            context.Set<Authorization>().Add(dataTransferAuthorization.ToAuthorization());

        }
        public void Update(DataTransferAuthorization dataTransferAuthorization)
        {
            using (var database = new EntityModel())
            {
                var authorization = database.Authorization.Find(dataTransferAuthorization.Id);
                authorization.Password = dataTransferAuthorization.Password;
                authorization.Confirm = dataTransferAuthorization.Confrim;
                database.SaveChanges();
            }
        }
        public void Delete(DataTransferAuthorization dataTransferAuthorization)
        {
            Authorization auth = dataTransferAuthorization.ToAuthorization();
            auth = context.Set<Authorization>().Find(auth.Id);
            context.Set<Authorization>().Remove(auth);
        }
        public IEnumerable<DataTransferAuthorization> GetAll(Func<DataTransferAuthorization, Boolean> predicate)
        {
            return context.Set<Authorization>().ToList().Select(x => x.ToDataTransferAuthorization()).Where(predicate);
        }
        public DataTransferAuthorization Get(Func<DataTransferAuthorization, Boolean> predicate)
        {
            try
            {
                var authorize = context.Set<Authorization>().ToList();
                var userAuthorize = authorize.Select(x => x.ToDataTransferAuthorization()).FirstOrDefault(predicate);
                return userAuthorize;
            }
            catch
            {
                return null;
            }
        }
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
