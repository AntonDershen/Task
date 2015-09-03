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
    public class UserRepository : IRepository<User>
    {
        private DatabaseContext context;
        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }
        public User Find(int id)
        {
            return context.Users.Find(id);
        }
        public void Create(User user)
        {
            context.Users.Add(user);
        }
        public IEnumerable<User> Get(Func<User, Boolean> predicate)
        {
            return context.Users.Where(predicate);
        }
        public void Delete(int id)
        {
            User user = this.Find(id);
            context.Users.Remove(user);
        }

    }
}
