using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
using DataAccess.Interface.Repository;
using System.Data.Entity;
namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
        {
            private DbContext context;
            public UserRepository(DbContext context)
                {
                    this.context = context;
                }
            public User Find(int id)
            {
                return context.Set<User>().Find(id);
            }
            public IEnumerable<User> GetAll()
            {
                return context.Set<User>().ToList();
            }
            public void Create(User user)
            {
                context.Set<User>().Add(user);
            }
            public void Update(User user)
            {
                throw new NotImplementedException();
            }
            public void Delete(User user)
            {
                user = context.Set<User>().Single(u => u.Id == user.Id);
                context.Set<User>().Remove(user);
            }
            public IEnumerable<User> GetAll(Func<User, Boolean> predicate,int begin,int count)
            {
                return context.Set<User>().Where(predicate).Skip(begin).Take(count);
            }
            public User Get(Func<User, Boolean> predicate)
            {
                return context.Set<User>().FirstOrDefault(predicate);
            }
            public IEnumerable<Authorization> GetAuthorization(int id)
            {
                return context.Set<User>().Find(id).Authorizations;
            }
            public void UpdateRate(int rateCount, int userId)
            {
                using(var database = new EntityModel())
                {
                    var user = database.Users.Find(userId);
                    user.Rate += rateCount;
                    database.SaveChanges();
                }
            }
            public int GetRate(int userId)
            {
                return this.Find(userId).Rate;
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
