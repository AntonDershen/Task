using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.Repository;
using DataAccess.Interface.EntityFramework;
using System.Data.Entity;

namespace DataAccess.Repository
{
    public class AuthorizationRepository : IRepository<Authorization>
    {
        private  DbContext context;
        public AuthorizationRepository(DbContext context)
        {
  
            this.context = context;
        }
        public Authorization Find(int id)
        {
            return context.Set<Authorization>().Find(id);
        }
        public IEnumerable<Authorization> GetAll()
        {
            return context.Set<Authorization>();
        }
        public void Create(Authorization authorization)
        {
            context.Set<Authorization>().Add(authorization);
        }
        public void Update(Authorization authorization)
        {
            using (var database = new EntityModel())
            {
                var updateAuthorization = database.Authorization.Find(authorization.Id);
                updateAuthorization.Password = authorization.Password;
                updateAuthorization.Confirm = authorization.Confirm;
                database.SaveChanges();
            }
        }
        public void Delete(Authorization authorization)
        {
            context.Set<Authorization>().Remove(authorization);
        }
        public IEnumerable<Authorization> GetAll(Func<Authorization, Boolean> predicate,int begin,int count)
        {
            return context.Set<Authorization>().Where(predicate).Skip(begin).Take(count);
        }
        public Authorization Get(Func<Authorization, Boolean> predicate)
        {
            return context.Set<Authorization>().FirstOrDefault(predicate);
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
