using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class AuthorizationRepository : IRepository<Authorization>
    {
        private DatabaseContext context;
        public AuthorizationRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Authorization> GetAll()
        {
            return context.Authorization;
        }
        public Authorization Find(int id)
        {
            return context.Authorization.Find(id);
        }
        public void Create(Authorization authorization)
        {
            context.Authorization.Add(authorization);
        }
        public IEnumerable<Authorization> Get(Func<Authorization, Boolean> predicate)
        {
            return context.Authorization.Where(predicate);
        }
        public void Delete(int id)
        {
            Authorization authorization = this.Find(id);
            context.Authorization.Remove(authorization);
        }
    }
}
